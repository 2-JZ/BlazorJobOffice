using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ContactsService : IContactsService
    {
        private IHttpService _httpService;

        public ContactsService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<int> Create(Contact contact)
        {
            var result = await _httpService.Post<Contact>("Contacts/addContact", contact);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"/Contacts/{id}");
            return id;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Contact>>("Contacts");
        }

        public Task<Contact> GetById(int id)
        {
            return _httpService.Get<Contact>($"/Contacts/{id}");
        }

        public async Task<int> Update(Contact contact)
        {
            var result = await _httpService.Put<Contact>($"/Contacts/{contact.Id}", contact);
            return result.Id;
        }
    }
}
