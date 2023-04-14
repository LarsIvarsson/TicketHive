using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
<<<<<<< HEAD
    public interface ICartService
    {
        Task<List<CartItemsModel>> GetShoppingCartAsync(string userName);
        Task AddToCartAsync(string userName, EventModel addEvent);
        Task RemoveFromCartAsync(CartItemsModel removeEvent);
        Task IncreaceQuantity(CartItemsModel item);
        Task DecreaceQuantity(CartItemsModel item);
    }
}
=======
	public interface ICartService
	{
		Task<List<CartItemsModel>> GetShoppingCartAsync(string userName);

		Task AddToCartAsync(string userName, EventModel addEvent);

		Task RemoveFromCartAsync(string userName, CartItemsModel removeEvent);

		Task IncreaceQuantity(string userName, CartItemsModel item);

		Task DecreaceQuantity(string userName, CartItemsModel item);

	}
}
>>>>>>> master
