using BlazorApp.Helpers;
using BlazorApp.Services;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Toast.Configuration;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Add Blazored.Toast service here
            //builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredToast();

            // Add this to configure the Toast settings globally
            //builder.Services.Configure<Blazored.Toast.Configuration.ToastConfiguration>(config =>
            //{
            //    config.Position = Blazored.Toast.Configuration.ToastPosition.TopRight;
            //    config.Timeout = 3000;  // Timeout value in milliseconds (3 seconds)
            //    config.ShowCloseButton = false;  // Don't show the close button
            //});



            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IBookCasesService, BookCasesService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<IContractorsService, ContractorsService>()
                .AddScoped<IContactsService, ContactsService>()
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<IShoppingCartService, ShoppingCartService>()
                .AddScoped<ICategoriesService, CategoriesService>()
                .AddScoped<IInvoiceService, InvoiceService>()
                .AddScoped<IStripePaymentService, StripePaymentService>();
            


            // Configure http client
            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();
        }
    }
}
