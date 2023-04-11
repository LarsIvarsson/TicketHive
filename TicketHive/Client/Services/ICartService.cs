using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public interface ICartService
    {
        Task Cookie();

        List<CartItemsModel> GetShoppingCartItem();

        Task AddToCartAsync(EventModel addEvent);

        Task RemoveFromCartAsync(CartItemsModel removeEvent);

        Task IncreaceQuantity(CartItemsModel item);

        Task DecreaceQuantity(CartItemsModel item);
    }
}
