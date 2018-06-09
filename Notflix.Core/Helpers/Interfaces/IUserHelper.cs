namespace Notflix.Core.Helpers
{
	public interface IUserHelper
	{
		string HashPassword(string password);

		bool VerifyPassword(string hash, string password);
	}
}