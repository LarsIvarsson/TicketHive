using Blazored.LocalStorage;
using Blazored.Toast.Services;
using TicketHive.Client.Services;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService localStorage;
        private List<CartItemsModel>? shoppingCart;

        public CartService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            shoppingCart = new List<CartItemsModel>();//
        }

        public async Task<List<CartItemsModel>> GetShoppingCartAsync(string userName)
        {
			List<CartItemsModel> shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);

            if(shoppingCart == null)
            {
                shoppingCart = new();
            }

            return shoppingCart;
        }

        public async Task AddToCartAsync(string userName, EventModel addEvent)
        {
			List<CartItemsModel> shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>(userName);

            if(shoppingCart == null)
            {
                shoppingCart = new();
            }

            if(shoppingCart.Any(i  => i.Event.Id == addEvent.Id))
            {
                shoppingCart.First(i => i.Event.Id == addEvent.Id).Quantity++;
            }

            else
            {
				CartItemsModel newCartItem = new()
				{
					Event = addEvent,
					Quantity = 1,
				};

				shoppingCart.Add(newCartItem);
			}

			await localStorage.SetItemAsync<List<CartItemsModel>>(userName, shoppingCart);
        }

        public async Task IncreaceQuantity(CartItemsModel item)
        {
            item.Quantity++;
            await localStorage.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);

        }

        public async Task DecreaceQuantity(CartItemsModel item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                await localStorage.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);
            }

            else if(item.Quantity == 1)
            {
                await RemoveFromCartAsync(item);
            }
        }
        public async Task RemoveFromCartAsync(CartItemsModel removeEvent)
        {
            shoppingCart.Remove(removeEvent);
            await localStorage.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);

            //shoppingCart = await localStorage.GetItemAsync<List<CartItemsModel>>("shoppingCartCookies");
            //shoppingCart.Remove(removeEvent);
            //await localStorage.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);
        }
    }
}