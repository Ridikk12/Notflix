using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotFlix2.ViewModels.VideoViewModels
{
    public class VideoUploadViewModel
    {
		public string VideoName { get; set; }
        public string VideoDescription { get; set; }
		public List<VideoGenderViewModel> VideoGenders { get; set; } = new List<VideoGenderViewModel>();
		public IFormFile VideoFile { get; set; }
	}
}
