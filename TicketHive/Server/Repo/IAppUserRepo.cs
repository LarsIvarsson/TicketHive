using TicketHive.Server.Models;

namespace TicketHive.Server.Repo
{
	public interface IAppUserRepo
	{
		Task<ApplicationUser?> GetUserByUsernameAsync(string AppUsername);
		Task<bool> PutAppUserAsync(string AppUsername, string Country);
		Task<bool> ChangePasswordAsync(string AppUsername, string currentPassword, string newPassword);
	}
}