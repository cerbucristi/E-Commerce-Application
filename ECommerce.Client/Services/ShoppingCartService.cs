using ECommerce.Client.ViewModels;
using Blazored.LocalStorage;
using ECommerce.Client.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Client.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private const string CartKey = "ShoppingCart";
        private readonly ILocalStorageService _localStorageService;

        public ShoppingCartService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<List<CartItemViewModel>> GetCartItems()
        {
            return await _localStorageService.GetItemAsync<List<CartItemViewModel>>(CartKey) ?? new List<CartItemViewModel>();
        }

        public async Task AddToCart(CartItemViewModel cartItem)
        {
            var cartItems = await GetCartItems();

            // Check if the cart item already exists in the cart
            if (!cartItems.Any(p => p.ProductId == cartItem.ProductId))
            {
                cartItems.Add(cartItem);
                await SaveCartItems(cartItems);
            }
        }

        public async Task RemoveFromCart(CartItemViewModel cartItem)
        {
            var cartItems = await GetCartItems();
            var existingCartItem = cartItems.FirstOrDefault(p => p.ProductId == cartItem.ProductId);

            if (existingCartItem != null)
            {
                cartItems.Remove(existingCartItem);
                await SaveCartItems(cartItems);
            }
        }

        public async Task IncreaseQuantity(CartItemViewModel cartItem)
        {
            var cartItems = await GetCartItems();
            var existingCartItem = cartItems.FirstOrDefault(p => p.ProductId == cartItem.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                await SaveCartItems(cartItems);
            }
        }

        public async Task DecreaseQuantity(CartItemViewModel cartItem)
        {
            var cartItems = await GetCartItems();
            var existingCartItem = cartItems.FirstOrDefault(p => p.ProductId == cartItem.ProductId);

            if (existingCartItem != null && existingCartItem.Quantity > 1)
            {
                existingCartItem.Quantity--;
                await SaveCartItems(cartItems);
            }
        }

        public async Task ClearCart()
        {
            await _localStorageService.RemoveItemAsync(CartKey);
        }

        private async Task SaveCartItems(List<CartItemViewModel> cartItems)
        {
            await _localStorageService.SetItemAsync(CartKey, cartItems);
        }
    }
}
