using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notflix.Services.User.Interfaces
{
    public interface IUserAccountService
    {
		Task<bool> RegisterUser(string email, string userPassword);
		Task<bool> Login(string email, string userPassword);

	}
}
