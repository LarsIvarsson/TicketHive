using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{

	public interface ICartService
	{
		Task<List<CartItemsModel>> GetShoppingCartAsync(string userName);

		Task AddToCartAsync(string userName, EventModel addEvent);

		Task RemoveFromCartAsync(string userName, CartItemsModel removeEvent);

		Task IncreaceQuantity(string userName, CartItemsModel item);

		Task DecreaceQuantity(string userName, CartItemsModel item);

		Task EmptyShoppingCartAsync(string UserName);
	}
}
