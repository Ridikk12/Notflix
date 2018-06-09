using Notflix.Domain.Videos;
using System.Collections.Generic;

namespace Notflix.Domain
{
	public class Video : BaseEntity
    {
		public string VideoName { get; set; }
		public string VideoUrl { get; set; }
		public string VideoPrice { get; set; }
		public virtual ICollection<VideoGender> Genders { get; set; }
		public Video()
		{
			Genders = new List<VideoGender>();
		}
	}
}
