using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Notflix.Services;
using NotFlix.DataTransferObjects.Video;
using NotFlix2.ViewModels.Shared;
using NotFlix2.ViewModels.VideoViewModels;

namespace NotFlix2.Controllers
{

	[Authorize]
	public class VideoController : Controller
	{
		private readonly IHostingEnvironment environment;
		private readonly IVideoService _videoService;
		private readonly IConfiguration _configuration;


		public VideoController(IHostingEnvironment env, IVideoService videoService, IConfiguration configuration)
		{
			environment = env;
			_videoService = videoService;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> Download(string name)
		{
			var memory = new MemoryStream();

			var uploads = Path.Combine(environment.WebRootPath, "uploads/vid1.mp4");
			return File(System.IO.File.OpenRead(uploads), "video/mp4");

		}

		[HttpGet]
		public async Task<IActionResult> GetGenders()
		{
			return Json(await _videoService.GetGenders());
		}


		//TODO: REFACTOR !
		[HttpPost]
		public async Task<IActionResult> Upload([FromForm]VideoUploadViewModel viewModel)
		{
			try
			{
				if (viewModel.VideoFile != null)
				{
					var uploadFolder = _configuration["UploadFolder:Video"];
					var uploadPath = Path.Combine(environment.WebRootPath, uploadFolder);

					if (!Directory.Exists(uploadPath))
						Directory.CreateDirectory(uploadPath);

					VideoUploadDto dto = MapToDto(viewModel);

					await _videoService.UploadVideo(dto, uploadPath);
				}
			}
			catch (Exception Ex)
			{
				return Json(new ResultViewModel { IsSucces = false, Message = Ex.Message });
			}

			return Json(new ResultViewModel { IsSucces = true, Message = "File uploaded"});
		}

		private static VideoUploadDto MapToDto(VideoUploadViewModel viewModel)
		{
			VideoUploadDto dto = new VideoUploadDto
			{
				VideoFile = viewModel.VideoFile,
				VideoName = viewModel.VideoName
			};

			foreach (var gender in viewModel.VideoGenders)
			{
				dto.VideoGenders.Add(new VideoGendersDto() { GenderName = gender.GenderName, Id = gender.Id });
			}

			return dto;
		}
	}

}