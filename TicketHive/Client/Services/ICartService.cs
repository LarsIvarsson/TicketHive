using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public interface ICartService
    {
        Task<List<CartItemsModel>> GetShoppingCartAsync(string userName);

        Task AddToCartAsync(string userName, EventModel addEvent);

        Task RemoveFromCartAsync(CartItemsModel removeEvent);

        Task IncreaceQuantity(string userName, CartItemsModel item);

        Task DecreaceQuantity(CartItemsModel item);

    }
}
