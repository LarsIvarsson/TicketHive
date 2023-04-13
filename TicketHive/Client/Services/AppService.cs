using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public class AppService : IAppService
    {
        private readonly HttpClient httpClient;
        private List<string> words = new();
        public AppService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // =========== EventModel Calls ==========
        public async Task<List<EventModel>?> GetEventsAsync()
        {
            var result = await httpClient.GetFromJsonAsync<List<EventModel>>("api/events");

            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<EventModel?> GetEventByIdAsync(int id)
        {
            var result = await httpClient.GetFromJsonAsync<EventModel>($"api/events/{id}");

            if (result != null)
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

        // =========== UserModel Calls ===========
        public async Task<List<UserModel>?> GetUsersAsync()
        {
            var result = await httpClient.GetFromJsonAsync<List<UserModel>>("api/users");

            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<UserModel?> GetUserByUsernameAsync(string UserName)
        {
            var result = await httpClient.GetFromJsonAsync<UserModel>($"api/users/{UserName}");

            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task PutUserAsync(int id, UserModel model)
        {
            await httpClient.PutAsJsonAsync($"api/users/{id}", model);
        }

        // ========== ApplicationUser Calls ============
        public async Task<string?> GetUserCountryByUsernameAsync(string AppUsername)
        {
            var response = await httpClient.GetAsync($"api/appusers/{AppUsername}");
            var json = await response.Content.ReadAsStringAsync();

            if (json != null)
            {
                return json;
            }
            return null;
        }
        public async Task PutAppUserAsync(string AppUsername, string Country)
        {
            words.Add(Country);
            var jsonList = JsonConvert.SerializeObject(words);
            await httpClient.PutAsJsonAsync($"api/appusers/{AppUsername}", jsonList);
            words.Clear();
        }
        public async Task PutAppUserAsync(string AppUsername, string currentPassword, string newPassword)
        {
            words.Add(currentPassword);
            words.Add(newPassword);
            var jsonList = JsonConvert.SerializeObject(words);
            await httpClient.PutAsJsonAsync($"api/appusers/{AppUsername}", jsonList);
            words.Clear();
        }
    }
}