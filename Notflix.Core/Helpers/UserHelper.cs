using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notflix.Core.Helpers
{
    public class UserHelper : IUserHelper
    {

		public string HashPassword(string password)
		{
			return Crypto.HashPassword(password);
		}

		public bool VerifyPassword(string hash, string password)
		{
			return Crypto.VerifyHashedPassword(hash, password);
		}
	}
}
