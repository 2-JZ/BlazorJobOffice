namespace BlazorApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<int> Create(Category category);
        Task<int> Delete(int Id);
        Task<int> Update(Category category);
        Task<Category> GetById(int Id);
    }
}