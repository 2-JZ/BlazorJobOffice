using BlazorApp.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpService _httpService;
        private ShoppingCartModel cart = new ShoppingCartModel(); // Instancja koszyka
        private readonly IJSRuntime jsRuntime; // Definiowanie pola IJSRuntime

        // Konstruktor do inicjalizacji _httpService i jsRuntime
        public ShoppingCartService(IHttpService httpService, IJSRuntime jsRuntime)
        {
            _httpService = httpService;
            this.jsRuntime = jsRuntime;
        }

        // Implementacja właściwości Cart według interfejsu
        public ShoppingCartModel Cart => cart; // Zwróć wewnętrzną instancję koszyka

        // Ustawienie koszyka (teraz zwraca Task)
        public async Task SetCart(ShoppingCartModel cart)
        {
            this.cart = cart;
            await SaveCartToLocalStorage(); // Zapisz koszyk do local storage
        }

        // Zapisz obecny koszyk do local storage
        private async Task SaveCartToLocalStorage()
        {
            var cartJson = System.Text.Json.JsonSerializer.Serialize(cart);
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "shoppingCart", cartJson);
        }

        // Załaduj koszyk z local storage
        private async Task LoadCartFromLocalStorage()
        {
            var cartJson = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "shoppingCart");
            if (!string.IsNullOrEmpty(cartJson))
            {
                cart = System.Text.Json.JsonSerializer.Deserialize<ShoppingCartModel>(cartJson);
            }
        }

        // Pobierz koszyk według ID z API
        public async Task<ShoppingCartModel> GetCartById(int cartId)
        {
            return await _httpService.Get<ShoppingCartModel>($"api/cart/{cartId}");
        }

        // Dodaj przedmiot do koszyka
        public async Task AddItemToCart(int cartId, CartItem item)
        {
            await _httpService.Post<object>($"api/cart/{cartId}/items", item);
            cart.Items.Add(item);
            await SaveCartToLocalStorage();
        }

        // Usuń przedmiot z koszyka
        public async Task RemoveItemFromCart(int cartId, int productId)
        {
            await _httpService.Delete($"api/cart/{cartId}/items/{productId}");
            var item = cart.Items.Find(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
                await SaveCartToLocalStorage();
            }
        }

        // Wyczyść wszystkie przedmioty w koszyku
        public async Task ClearCart()
        {
            cart.Items.Clear();
            await SaveCartToLocalStorage();
        }

        // Nowa metoda do pobierania koszyka
        public async Task<ShoppingCartModel> GetCart()
        {
            await LoadCartFromLocalStorage(); // Załaduj koszyk z local storage
            return cart; // Zwróć aktualny koszyk
        }
    }
}
