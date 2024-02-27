using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IHttpService _httpService;

        public CategoriesService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            return _httpService.Get<IEnumerable<Category>>("/Category");
        }

        public async Task<int> Create(Category category)
        {
            var result = await _httpService.Post<Category>("Category/addCategory", category);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"/Category/{id}");
            return id;
        }

        public async Task<int> Update(Category category)
        {
            var result = await _httpService.Put<Category>($"/Category/{category.Id}", category);
            return result.Id;
        }

        public Task<Category> GetById(int id)
        {
            return _httpService.Get<Category>($"/Category/{id}");
        }
    }
}

