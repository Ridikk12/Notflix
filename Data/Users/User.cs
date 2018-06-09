namespace Notflix.Domain
{
	public class User : BaseEntity
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public bool IsAdmin { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public static User CreateNewUser(string email, bool isAdmin, string password)
		{
			Domain.User newUser = new Domain.User();
			newUser.CreateBy = email;
			newUser.Email = email;
			newUser.IsAdmin = isAdmin;
			newUser.Password = password;
			return newUser;
		}
	}
}
