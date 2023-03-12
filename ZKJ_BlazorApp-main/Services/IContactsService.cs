using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<int> Create(Contact contact);
        Task<int> Delete(int id);
        Task<int> Update(Contact contact);
        Task<Contact> GetById(int id);
    }
}
