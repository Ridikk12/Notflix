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
	public class GenderRepository : AbstractRepository, IGenderRepository
	{
		public GenderRepository(NotflixDbContext dbContext) : base(dbContext)
		{
		}

		public Task Add(Gender entity)
		{
			throw new NotImplementedException();
		}

		public Task<Gender> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Gender>> Get(List<Guid> ids)
		{
			throw new NotImplementedException();
		}
		public Task<List<Gender>> GetAll()
		{
			return _dbContext.Genders.ToListAsync();
		}


	}
}
