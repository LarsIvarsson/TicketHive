using TicketHive.Client.Services;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Managers
{
    public class CurrencyManager
    {
        private readonly ICurrencyService currencyService;

        public string Currency { get; set; }

        public CurrencyManager(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public async Task<Root?> GetCurrencies()
        {
            Root currency = await currencyService.GetCurrenciesAsync();

            return currency;
        }
    }
}
