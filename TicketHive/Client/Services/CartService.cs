namespace TicketHive.Client.Services
{
	public class CartService : ICartService
	{
		private readonly ILocalStorageService localStorage;
		private List<CartItemsModel>? shoppingCart;
		public CartService(ILocalStorageService localStorage)
		{
			this.localStorage = localStorage;
		}

		public async Task<List<CartItemsModel>> GetShoppingCartAsync(string userName)
		{
			shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);

			if (shoppingCart == null)
			{
				shoppingCart = new();
			}
			return shoppingCart;
		}

		public async Task AddToCartAsync(string userName, EventModel addEvent)
		{
			shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);

			if (shoppingCart == null)
			{
				shoppingCart = new();
			}

			if (shoppingCart.Any(i => i.Event.Id == addEvent.Id))
			{
				shoppingCart.First(i => i.Event.Id == addEvent.Id).Quantity++;
			}
			else
			{
				CartItemsModel newCartItem = new()
				{
					EventId = addEvent.Id,
					Event = addEvent,
					Quantity = 1,
					Price = addEvent.Price,
				};

				shoppingCart.Add(newCartItem);
			}

			await localStorage.SetItemAsync<List<CartItemsModel>>(userName, shoppingCart);
		}

		public async Task IncreaceQuantity(string userName, CartItemsModel item)
		{
			shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);
			CartItemsModel? itemToUpdate = shoppingCart.FirstOrDefault(i => i.EventId == item.EventId);

			if (itemToUpdate != null)
			{
				itemToUpdate.Quantity++;
				await localStorage.SetItemAsync<List<CartItemsModel>>(userName, shoppingCart);
			}

		}

		public async Task DecreaceQuantity(string userName, CartItemsModel item)
		{
			shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);
			CartItemsModel? itemToUpdate = shoppingCart.FirstOrDefault(i => i.EventId == item.EventId);

			if (itemToUpdate != null)
			{
				if (itemToUpdate.Quantity > 1)
				{
					itemToUpdate.Quantity--;
					await localStorage.SetItemAsync<List<CartItemsModel>>(userName, shoppingCart);
				}
				else if (item.Quantity == 1)
				{
					await RemoveFromCartAsync(userName, item);
				}
			}
		}

		public async Task RemoveFromCartAsync(string userName, CartItemsModel removeEvent)
		{
			shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);
			CartItemsModel? itemToRemove = shoppingCart.FirstOrDefault(i => i.EventId == removeEvent.EventId);
			if (itemToRemove != null)
			{
				shoppingCart.Remove(itemToRemove);
				await localStorage.SetItemAsync<List<CartItemsModel>>(userName, shoppingCart);
			}
		}
	}
}

>>>>>>> master
