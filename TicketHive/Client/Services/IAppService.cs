using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
	public interface IAppService
	{
		Task<List<EventModel>?> GetEventsAsync();
		Task<EventModel?> GetEventByIdAsync(int id);
		Task PostEventAsync(EventModel model);
		Task PutEventAsync(int id, EventModel model);
		Task DeleteEventAsync(int id);
		Task<List<UserModel>?> GetUsersAsync();
		Task<UserModel?> GetUserByUsernameAsync(string UserName);
		Task PutUserAsync(int id, UserModel model);
		Task<string?> GetUserCountryByUsernameAsync(string AppUsername);
		Task<string?> PutAppUserCountryAsync(string AppUsername, string Country);
		Task<string?> PutAppUserAsync(string AppUsername, string currentPassword, string newPassword);
	}
}