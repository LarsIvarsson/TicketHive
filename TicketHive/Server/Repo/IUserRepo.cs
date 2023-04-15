using TicketHive.Shared.Models;

namespace TicketHive.Server.Repo
{
	public interface IUserRepo
	{
		Task<List<UserModel>?> GetUsersAsync();
		Task<UserModel?> GetUserByUsernameAsync(string UserName);
		Task<UserModel?> GetUserByUsernameIncludeEventsAsync(string UserName);

		Task<bool> PostUserAsync(UserModel model);
		Task<bool> PutUserAsync(int id, UserModel model);
	}
}


