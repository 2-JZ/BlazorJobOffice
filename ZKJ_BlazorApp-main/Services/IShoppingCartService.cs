using BlazorApp.Models;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetCartById(int cartId);
        Task AddItemToCart(int cartId, CartItem item);
        Task RemoveItemFromCart(int cartId, int productId);
    }
}
