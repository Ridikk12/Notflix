using Microsoft.EntityFrameworkCore;
using Notflix.Domain;
using Notlifx.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlifx.Data.Repositories
{
	public class VideoRepository : AbstractRepository, IVideoRepository
	{
		public VideoRepository(NotflixDbContext dbContext) : base(dbContext)
		{
		}

		public Task Add(Video entity)
		{
			return _dbContext.Videos.AddAsync(entity);
		}

		public Task<Video> Get(Guid id)
		{
			return _dbContext.Videos.Where(X => X.Id == id).FirstOrDefaultAsync();
		}

		public Task<List<Video>> Get(List<Guid> ids)
		{
			return _dbContext.Videos.Where(x=> ids.Contains(x.Id)).ToListAsync();
		}

		public Task<List<Video>> GetAll()
		{
			return _dbContext.Videos.ToListAsync();
		}

		public int Save()
		{
			return _dbContext.SaveChanges();
		}
	}
}
