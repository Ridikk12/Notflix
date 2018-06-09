using Notflix.Domain.Videos;
using System.Collections;
using System.Collections.Generic;

namespace Notflix.Domain
{
	public class Gender : BaseEntity
    {
		public string GenderName { get; set; }
		public ICollection<VideoGender> VideoGenders { get; set; }
    }
}
