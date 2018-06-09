using System;

namespace Notflix.Domain.Videos
{
	public class VideoGender : BaseEntity
    {
		public Guid VideoId { get; set; }
		public Guid GenderId { get; set; }

		public Video Video { get; set; }
		public Gender Gender { get; set; }
    }
}
