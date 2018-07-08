using Microsoft.EntityFrameworkCore;
using Notflix.Domain;
using Notflix.Domain.Videos;

namespace Notlifx.Data
{
	public class NotflixDbContext : DbContext
	{
		public NotflixDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Video> Videos { get; set; }
		public DbSet<UserHistory> UserHistories { get; set; }
		public DbSet<VideoGender> VideoGenders { get; set; }
		public DbSet<Gender> Genders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<Payment>().ToTable("Payment");
			modelBuilder.Entity<Video>().ToTable("Video");
			modelBuilder.Entity<UserHistory>().ToTable("UserHistory");
			modelBuilder.Entity<VideoGender>().ToTable("VideoGender");
			modelBuilder.Entity<Gender>().ToTable("Gender");

		


			modelBuilder.Entity<VideoGender>()
				.HasKey(x => new { x.GenderId, x.VideoId });

			modelBuilder.Entity<VideoGender>()
				.HasOne(x => x.Gender)
				.WithMany(x => x.VideoGenders)
				.HasForeignKey(x => x.GenderId);

			modelBuilder.Entity<VideoGender>()
			.HasOne(x => x.Video)
			.WithMany(x => x.Genders)
			.HasForeignKey(x => x.VideoId);

			modelBuilder.Entity<Payment>()
				.HasOne(x => x.User);

			modelBuilder.Entity<Payment>()
				.HasOne(x => x.Video);

		}



	}
}
