using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Client.Managers;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public class CurrencyService : ICurrencyService
    {
		/// <summary>
		/// Retrieves the latest currency exchange rates asynchronously from the API.
		/// </summary>
		public async Task<Root?> GetCurrenciesAsync()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.apilayer.com/exchangerates_data/latest?symbols=EUR,GBP&base=SEK");
            requestMessage.Headers.Add("apikey", "w7ocDhWDa9ekbz4TbMH26wraRGSYHVGo");
            
            HttpResponseMessage response = await new HttpClient().SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (responseString != null)
                {
                    var result = JsonConvert.DeserializeObject<Root?>(responseString);
                    
                    if (result != null)
                    {
                        CurrencyManager.RatesRecieved = DateTime.Now;
                        CurrencyManager.Rates = result.Rates;

                        return result;
                    }
                }
            }

            return null;
        }
    }
}