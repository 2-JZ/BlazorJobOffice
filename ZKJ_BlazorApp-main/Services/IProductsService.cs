using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductsService
{
    Task<IEnumerable<Product>> GetAll(); // This gets all products
    Task<IEnumerable<Product>> GetByCategory(int categoryId); // This gets products by category
    Task<int> Create(Product product);
    Task<int> Delete(int id);
    Task<int> Update(Product product);
    Task<Product> GetById(int id);
}
