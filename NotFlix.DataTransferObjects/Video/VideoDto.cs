using System;

namespace NotFlix.DataTransferObjects.Video
{
	public class VideoDto
	{
		public Guid Id { get; set; }
		public string VideoName { get; set; }
		public string VideoUrl { get; set; }
		public string VideoPrice { get; set; }
		public string VideoGender { get; set; }
	}
}
