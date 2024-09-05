using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoriesService
{
    Task<IEnumerable<Category>> GetAll();
    Task<int> CreateCategory(Category category); // Update to byte[]
    Task<int> Delete(int id);
    Task<int> Update(Category category);
    Task<Category> GetById(int id);
}
