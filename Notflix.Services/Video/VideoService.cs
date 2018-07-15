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

			string fullPath = path + '\\' + videoDto.VideoName + ".mp4";
			Video newVideo = CreateNewVideo(videoDto, fullPath);

			await _videoRepository.Add(newVideo);
			var result = _videoRepository.Save();

			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				await videoDto.VideoFile.CopyToAsync(stream);
			}
		}

		private static Video CreateNewVideo(VideoUploadDto videoDto, string fullPath)
		{
			Video newVideo = new Video
			{
				Id = Guid.NewGuid(),
				Version = 0,
				VideoName = videoDto.VideoName,
				VideoUrl = fullPath
			};

			foreach (var gender in videoDto.VideoGenders)
			{
				newVideo.Genders.Add(
					new Domain.Videos.VideoGender { Id = Guid.NewGuid(), VideoId = newVideo.Id, GenderId = gender.Id, CreateDate = DateTime.Now, Version = 0, CreateBy = "Admin" });
			}

			return newVideo;
		}

		public async Task<List<VideoDto>> GetAllVideo()
		{
			var dtos = new List<VideoDto>();
			try
			{
				List<Video> videos = await _videoRepository.GetAll();
				

				foreach (var video in videos)
				{
					var gender = video.Genders.FirstOrDefault();
					string genderStr = "";
					if (gender != null)
						genderStr = gender.Gender.GenderName;

					dtos.Add(new VideoDto
					{ Id = video.Id, VideoName = video.VideoName, VideoPrice = video.VideoPrice, VideoUrl = video.VideoUrl, VideoGender = genderStr });
				}
			}
			catch(Exception Ex)
			{
				var  tt = Ex;
			}
			return dtos;
		}

        public async Task<VideoDto> GetVideo(Guid videoId)
        {
            try
            {
                var video = await _videoRepository.Get(videoId);
                return new VideoDto
                {
                    Id = video.Id,
                    VideoGender = video.Genders.FirstOrDefault().Gender.GenderName,
                    VideoName = video.VideoName,
                    VideoPrice = video.VideoPrice,
                    VideoUrl = video.VideoUrl
                };
            }
            catch(Exception ex)
            {
                return new VideoDto();
            }

        }
    }
}
