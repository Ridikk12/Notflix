using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotFlix.DataTransferObjects.Video
{
	public class VideoUploadDto
	{
		public string VideoName { get; set; }
		public List<VideoGendersDto> VideoGenders { get; set; } = new List<VideoGendersDto>();
		public IFormFile VideoFile { get; set; }
	}
}
