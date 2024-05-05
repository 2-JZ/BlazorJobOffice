using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _httpService.Get<IEnumerable<User>>("user/users");
        }

        public async Task<User> AddUser(User user)
        {
            // Wywo�aj odpowiedni endpoint API do dodania u�ytkownika
            return await _httpService.Post<User>("user/add", user);
        }

        public async Task ResetPassword(string email)
        {
            // Wywo�aj odpowiedni endpoint API do resetowania has�a
            await _httpService.Post($"user/resetpassword/{email}", null);
        }
    }
}
