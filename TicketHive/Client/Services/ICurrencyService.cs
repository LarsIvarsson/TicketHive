using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public interface ICurrencyService
    {
        Task<Root?> GetCurrenciesAsync();
    }
}