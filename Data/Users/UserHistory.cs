using System;

namespace Notflix.Domain
{
	public class UserHistory : BaseEntity
	{
		public User User { get; set; }
		public Video Video { get; set; }
		public DateTime WatchDate { get; set; }

	}
}
