using Blazored.LocalStorage;
using TicketHive.Client.Services;
using TicketHive.Shared.Models;

namespace TicketHive.Client.Services
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService localStorageService;
        private List<CartItemsModel> shoppingCart;

        public CartService(ILocalStorageService localStorage)
        {
            //this.localStorage = localStorage;
            //this.shoppingCart = shoppingCart;
            this.localStorageService = localStorage;
        }



        public async Task Cookie()
        {
            shoppingCart = await localStorageService.GetItemAsync<List<CartItemsModel>>("shoppingCartCookies");

            if (shoppingCart == null)
            {
                await localStorageService.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", new List<CartItemsModel>());

                shoppingCart = await localStorageService.GetItemAsync<List<CartItemsModel>>("shoppingCartCookies");
            }
        }

        public List<CartItemsModel> GetShoppingCartItem()
        {
            return shoppingCart;
        }

        public async Task AddToCartAsync(EventModel addEvent)
        {
            CartItemsModel newCartItem = new()
            {
                Event = addEvent,
                Quantity = 1,
            };

            shoppingCart.Add(newCartItem);
            await localStorageService.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);
        }

        public async Task IncreaceQuantity(CartItemsModel item)
        {
            item.Quantity++;
            await localStorageService.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);
        }

        public async Task DecreaceQuantity(CartItemsModel item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                await localStorageService.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);
            }
            else
            {
                await RemoveFromCartAsync(item);
            }
        }
        public async Task RemoveFromCartAsync(CartItemsModel removeEvent)
        {
            shoppingCart.Remove(removeEvent);
            await localStorageService.SetItemAsync<List<CartItemsModel>>("shoppingCartCookies", shoppingCart);
        }

    }
}
