using BlazorApp.Models;
using System.Threading.Tasks;

public interface IShoppingCartService
{
    ShoppingCartModel Cart { get; } // Właściwość do pobierania koszyka
    Task SetCart(ShoppingCartModel cart); // Ustaw koszyk
    Task<ShoppingCartModel> GetCart(); // Nowa metoda do pobierania koszyka
    Task<ShoppingCartModel> GetCartById(int cartId); // Metoda do pobierania koszyka według ID
    Task AddItemToCart(int cartId, CartItem item); // Metoda do dodawania przedmiotu
    Task RemoveItemFromCart(int cartId, int productId); // Metoda do usuwania przedmiotu
    Task ClearCart(); // Metoda do czyszczenia koszyka
}
