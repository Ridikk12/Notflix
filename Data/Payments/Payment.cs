using System;

namespace Notflix.Domain
{
	public class Payment : BaseEntity
	{
		public User User { get; set; }
		public Video Video { get; set; }
		public DateTime PaymentDate { get; set; }
		public bool IsBooked { get; set; }
	}
}
