using Notflix.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notlifx.Data.Repositories
{
	public interface IUserRepository : IRepository<User>
    {
		Task<User> Get(string email, string userPassword);
		Task<User> Get(string email);

	}
}
