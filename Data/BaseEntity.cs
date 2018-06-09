using System;
using System.ComponentModel.DataAnnotations;

namespace Notflix.Domain
{
	public class BaseEntity
    {
		[Key]
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public string CreateBy { get; set; }
		public int Version { get; set; }
    }
}
