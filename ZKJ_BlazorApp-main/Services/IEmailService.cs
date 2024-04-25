using System.Threading.Tasks;

namespace BlazorApp.Services
{  
        public interface IEmailService
        {
            Task SendEmailAsync(string from, string to, string subject, string message);
        }
}
