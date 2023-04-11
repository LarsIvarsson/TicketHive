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

		public async Task<string?> GetUserCountryByUsernameAsync(string AppUsername)
		{
			var result = await httpClient.GetFromJsonAsync<string>($"api/appusers/{AppUsername}");

			if (result != null)
			{
				return result;
			}

			return null;
		}
	}
}