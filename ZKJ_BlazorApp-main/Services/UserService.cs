using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;

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
            return await _httpService.Post<User>("user/add", user);
        }

        public async Task ResetPassword(string email)
        {
            var request = new { Email = email };
            await _httpService.Post<object>("user/reset-password", request);
        }
    }
}
