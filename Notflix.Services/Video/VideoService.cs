using Notflix.Domain;
using NotFlix.DataTransferObjects.Video;
using Notlifx.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Notflix.Services
{
	public class VideoService : IVideoService
	{
		private readonly IGenderRepository _genderRepository;
		private readonly IVideoRepository _videoRepository;

		public VideoService(IGenderRepository genderRepository, IVideoRepository videoRepository)
		{
			_genderRepository = genderRepository;
			_videoRepository = videoRepository;
		}

		public async Task<List<VideoGendersDto>> GetGenders()
		{
			var genders = await _genderRepository.GetAll();
			return genders.Select(x => new VideoGendersDto() { GenderName = x.GenderName, Id = x.Id }).ToList();
		}


		//TODO: Refactor !
		public async Task UploadVideo(VideoUploadDto videoDto, string path)
		{

			string fullPath = path + videoDto.VideoName + ".mp4";

			Video newVideo = new Video();
			newVideo.Id = Guid.NewGuid();
			newVideo.Version = 0;
			newVideo.VideoName = videoDto.VideoName;
			newVideo.VideoUrl = fullPath;

		

			foreach (var gender in videoDto.VideoGenders)
			{
				newVideo.Genders.Add(
					new Domain.Videos.VideoGender { Id = Guid.NewGuid(), VideoId = newVideo.Id, GenderId = gender.Id, CreateDate = DateTime.Now, Version = 0, CreateBy = "Admin" });
			}


			await _videoRepository.Add(newVideo);
			var result = _videoRepository.Save();

			using (var stream = new FileStream(path, FileMode.Create))
			{
				await videoDto.VideoFile.CopyToAsync(stream);
			}
		}


	}
}
