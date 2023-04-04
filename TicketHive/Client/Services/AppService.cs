using System.Net.Http.Json;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public class AppService : IAppService
    {
        private readonly HttpClient httpClient;

        public AppService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<EventModel>?> GetEventsAsync()
        {
            var result = await httpClient.GetFromJsonAsync<List<EventModel>>("api/events");

            if(result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<EventModel?> GetEventByIdAsync(int id)
        {
            var result = await httpClient.GetFromJsonAsync<EventModel>($"api/events/{id}");

            if(result != null)
            {
                return result;
            }

            return null;
        }

        public async Task PostEventAsync(EventModel model)
        {
            await httpClient.PostAsJsonAsync("api/events", model);
        }

        public async Task PutEventAsync(int id, EventModel model)
        {
            await httpClient.PutAsJsonAsync($"api/events/{id}", model);
        }

        public async Task DeleteEventAsync(int id)
        {
            await httpClient.DeleteAsync($"api/events/{id}");
        }
    }
}