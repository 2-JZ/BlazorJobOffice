using static BlazorApp.Pages.Checkout;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly HttpClient _httpClient;

        public StripePaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<bool> ProcessPayment(BlazorApp.Models.Payment paymentRequest)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/payment/process-payment", paymentRequest);
        //    return response.IsSuccessStatusCode;
        //}
    }
}