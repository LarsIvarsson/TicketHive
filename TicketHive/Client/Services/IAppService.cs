using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
	public interface IAppService
	{
		Task<List<EventModel>?> GetEventsAsync();
		Task<EventModel?> GetEventByIdAsync(int id);
		Task PostEventAsync(EventModel model);
		//Task PostUserAsync(UserModel model);
		Task PutEventAsync(int id, EventModel model);
		Task DeleteEventAsync(int id);
	}
}
