using Notflix.Domain;
using Notlifx.Data;
using System;
using System.Linq;

public static class DbInitializer
{
	public static void Initialize(NotflixDbContext context)
	{
		context.Database.EnsureCreated();

		if (context.Genders.Any())
		{
			return;   // DB has been seeded
		}

		var genders = new Gender[]
		{
			new Gender{ CreateBy = "Admin", CreateDate = DateTime.Now, GenderName = "Komedia", Version = 0, Id = Guid.NewGuid()},
			new Gender{ CreateBy = "Admin", CreateDate = DateTime.Now, GenderName = "Horror", Version = 0, Id = Guid.NewGuid()},
			new Gender{ CreateBy = "Admin", CreateDate = DateTime.Now, GenderName = "Akcja", Version = 0, Id = Guid.NewGuid()},
			new Gender{ CreateBy = "Admin", CreateDate = DateTime.Now, GenderName = "Dramat", Version = 0, Id = Guid.NewGuid()},
		};

		foreach(var gender in genders)
		{
			context.Genders.Add(gender);
		}

		context.SaveChanges();
	}
}