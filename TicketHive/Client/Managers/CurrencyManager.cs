using TicketHive.Client.Services;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Managers
{
    public class CurrencyManager
    {
        private readonly ICurrencyService currencyService;

        public static string? Currency { get; set; }
        public static Rates? Rates { get; set; } 
        public static DateTime RatesRecieved { get; set; }

        public CurrencyManager(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public async Task<Root?> GetCurrencies()
        {
            Root? currency = await currencyService.GetCurrenciesAsync();

            return currency;
        }

        public static async Task<decimal> ConvertAmount(string country, decimal amount)
        {
            if(country == "Sweden")
            {
                Currency = "SEK";
                return amount;
            }

            else if(country == "Great_Britain")
            {
                Currency = "£";
                if (Rates == null || RatesRecieved.Date.AddDays(1) < DateTime.Now)
                {
                    await new CurrencyService().GetCurrenciesAsync();
                }

                // Convert from SEK to GBP
                return amount * (decimal)Rates!.Pounds!;
            }

            else
            {
                Currency = "€";
                if (Rates == null || RatesRecieved.Date.AddDays(1) < DateTime.Now)
                {
                    await new CurrencyService().GetCurrenciesAsync();
                }

                // Convert from SEK to EUR
                return amount * (decimal)Rates!.Euro!;
            }
        }
    }
}
