using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notflix.Domain;

namespace Notlifx.Data.Repositories
{
	public class UserRepository : AbstractRepository, IUserRepository
	{

		public UserRepository(NotflixDbContext dbContext) : base(dbContext)
		{
		}

		public async Task Add(User entity)
		{
			await _dbContext.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public Task<User> Get(Guid id)
		{
			return _dbContext.Users.FindAsync(id);
		}

		public Task<List<User>> Get(List<Guid> ids)
		{
			return _dbContext.Users.Where(x => ids.Contains(x.Id)).ToListAsync();
		}

		public Task<User> Get(string email, string userPassword)
		{
			return _dbContext.Users.Where(x => x.Email == email && x.Password == userPassword).SingleOrDefaultAsync();
		}

		public Task<User> Get(string email)
		{
			return _dbContext.Users.Where(x => x.Email == email).SingleOrDefaultAsync();
		}
	}
}
