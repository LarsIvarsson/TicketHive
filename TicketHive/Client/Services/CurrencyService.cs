using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<Root?> GetCurrenciesAsync()
        {
            //var result = await new HttpClient().GetFromJsonAsync<List<CurrencyModel>>("api/currencies");

            //if (result != null)
            //{
            //    return result;
            //}

            //return null!;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.apilayer.com/exchangerates_data/latest?symbols=EUR&base=SEK");
            requestMessage.Headers.Add("apikey", "w7ocDhWDa9ekbz4TbMH26wraRGSYHVGo");
            
            HttpResponseMessage response = await new HttpClient().SendAsync(requestMessage);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Root?>(responseString);

            return result;
        }
    }
}
