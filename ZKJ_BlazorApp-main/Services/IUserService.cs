namespace BlazorApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> AddUser(User user);
        Task ResetPassword(string email);




    }
}