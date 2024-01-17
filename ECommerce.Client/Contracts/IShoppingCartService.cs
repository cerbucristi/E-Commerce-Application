using ECommerce.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Client.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemViewModel>> GetCartItems();
        Task AddToCart(CartItemViewModel item);
        Task RemoveFromCart(CartItemViewModel item);
        Task IncreaseQuantity(CartItemViewModel item);
        Task DecreaseQuantity(CartItemViewModel item);
        Task ClearCart();
    }
}
