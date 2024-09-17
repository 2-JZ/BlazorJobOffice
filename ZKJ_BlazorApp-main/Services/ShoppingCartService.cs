using BlazorApp.Models;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpService _httpService;

        public ShoppingCartService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        // Fetch the cart by its Id
        public async Task<ShoppingCart> GetCartById(int cartId)
        {
            return await _httpService.Get<ShoppingCart>($"api/cart/{cartId}");
        }

        // Add an item to the cart
        public async Task AddItemToCart(int cartId, CartItem item)
        {
            // Prepare the endpoint and post the item to the cart
            await _httpService.Post<object>($"api/cart/{cartId}/items", item);
        }

        // Remove an item from the cart
        public async Task RemoveItemFromCart(int cartId, int productId)
        {
            // Prepare the endpoint and make a delete request to remove the item
            await _httpService.Delete($"api/cart/{cartId}/items/{productId}");
        }
    }
}
 