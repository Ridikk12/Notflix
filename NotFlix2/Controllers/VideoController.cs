using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public VideoController(
            IHostingEnvironment env, 
            IVideoService videoService, 
            IConfiguration configuration,
            IMapper mapper)
        {
            environment = env;
            _videoService = videoService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Download(string name)
        {
            var memory = new MemoryStream();

            var uploads = Path.Combine(environment.WebRootPath, "Upload/TEst22.mp4");
            return File(System.IO.File.OpenRead(uploads), "video/mp4");

        }

        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            return Json(await _videoService.GetGenders());
        }


        //TODO: REFACTOR - Move logic from controller !
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

            return Json(new ResultViewModel { IsSucces = true, Message = "File uploaded" });
        }


        //Move to mapper class !
        private VideoUploadDto MapToDto(VideoUploadViewModel viewModel)
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

        [HttpGet]
        public async Task<IActionResult> GetUserVideos()
        {
            return Json(await _videoService.GetAllVideo());
        }
       

        [HttpGet]
        public async Task<IActionResult> GetVideoDetails(Guid videoId)
        {
            VideoDto video = await _videoService.GetVideo(videoId);
            VideoDetailsViewModel vm = _mapper.Map<VideoDetailsViewModel>(video);
            return Json(vm);
        }

    }

}