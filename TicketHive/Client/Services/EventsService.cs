//using Microsoft.Extensions.Logging;
//using System.Net.Http.Json;
//using TicketHive.Shared.Models;

//namespace TicketHive.Client.Services
//{
//    public class EventsService : IEventsService
//    {
//        private readonly HttpClient httpClient;

//        public EventsService(HttpClient httpClient)
//        {
//            this.httpClient = httpClient;
//        }
//        public async Task<bool> AddEventAsync(EventModel eventToAdd)
//        {
//            var result = await httpClient.PostAsJsonAsync("api/events", eventToAdd);

//            if (result.IsSuccessStatusCode)
//            {
//                return true;
//            }
//            return false;

//        }

//        public async Task<bool> AddEventToUserAsync(string username, int eventId)
//        {
//            var result = await httpClient.PutAsync($"api/events/{username}/{eventId}", null);

//            if (result.IsSuccessStatusCode)
//            {
//                return true;
//            }
//            return false;
//        }

//        public async Task<bool> DeleteEventAsync(int id)
//        {
//            var result = await httpClient.DeleteAsync($"api/events/{id}");

//            if (result.IsSuccessStatusCode)
//            {
//                return true;
//            }
//            return false;
//        }

//        public async Task<List<EventModel>?> GetAllEventsAsync()
//        {
//            var result = await httpClient.GetFromJsonAsync<List<EventModel>>("api/events");

//            if (result != null)
//            {
//                return result;
//            }
//            return null;
//        }

//        public async Task<List<EventModel>?> GetAllEventsFromUserAsync(string username)
//        {
//            var result = await httpClient.GetFromJsonAsync<List<EventModel>>($"api/events/user/{username}");

//            if (result != null)
//            {
//                return result;
//            }
//            return null;
//        }

//        public async Task<EventModel?> GetEventsByIdAsync()
//        {
//            var result = await httpClient.GetFromJsonAsync<EventModel>($"api/events/allevent/");

//            if (result != null)
//            {
//                return result;
//            }
//            return null;
//        }

//        public async Task<EventModel?> UpdateEventAsync(EventModel eventToupdate)
//        {
//            var result = await httpClient.PutAsJsonAsync($"api/events/{eventToupdate.Id}", eventToupdate);

//            if (result.IsSuccessStatusCode)
//            {
//                EventModel? updatedEvent = await result.Content.ReadFromJsonAsync<EventModel>();
//                return updatedEvent;
//            }
//            return null;
//        }
//    }
//}
