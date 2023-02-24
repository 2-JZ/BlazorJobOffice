using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class BookCasesService : IBookCasesService
    {
        private IHttpService _httpService;

        public BookCasesService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<IEnumerable<BookCase>> GetAll()
        {
            return _httpService.Get<IEnumerable<BookCase>>("/bookcases");
        }

        public async Task<int> Create(BookCase bookCase)
        {
            var result = await _httpService.Post<BookCase>("/bookcases", bookCase);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"/bookcases/{id}");
            return id;
        }

        public async Task<int> Update(BookCase bookCase)
        {
            var result = await _httpService.Put<BookCase>($"/bookcases/{bookCase.Id}", bookCase);
            return result.Id;
        }

        public Task<BookCase> GetById(int id)
        {
            return _httpService.Get<BookCase>($"/bookcases/{id}");
        }
    }
}