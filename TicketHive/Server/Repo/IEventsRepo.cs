using TicketHive.Shared.Models;

namespace TicketHive.Server.Repo
{
    public interface IEventsRepo
    {
        Task<List<EventModel>?> GetEventsAsync();
        Task<EventModel?> GetEventByIdAsync(int id);
        Task<bool> PostEventAsync(EventModel model);
        Task<bool> PutEventAsync(int id, EventModel model);         
        Task<bool> DeleteEventAsync(int id);
    }
}