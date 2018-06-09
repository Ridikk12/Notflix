using Notflix.Core.Helpers;
using Notflix.Services.User.Interfaces;
using Notlifx.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notflix.Services.User
{
	public class UserAccountService : IUserAccountService
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserHelper _userHelper;
		public UserAccountService(IUserRepository userRepository, IUserHelper userHelper)
		{
			_userRepository = userRepository;
			_userHelper = userHelper;
		}

		public async Task<bool> Login(string email, string userPassword)
		{
			var user = await _userRepository.Get(email);
			if (user != null) {
				bool isPasswordCorrect = _userHelper.VerifyPassword(user.Password, userPassword);
				return isPasswordCorrect;
			}
			return false;
		}

		public async Task<bool> RegisterUser(string email, string password)
		{
			try
			{
				var user = await _userRepository.Get(email);
				if (user != null)
					return false;

				var hashPassword = _userHelper.HashPassword(password);
				var newUser = Domain.User.CreateNewUser(email, false, hashPassword);

				await _userRepository.Add(newUser);
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}

	}
}
