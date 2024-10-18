using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductsService
{
    Task<IEnumerable<ProductRequest>> GetAll(); // This gets all products
    Task<IEnumerable<ProductRequest>> GetByCategory(int categoryId); // This gets products by category
    Task<int> Create(ProductRequest product);
    Task<int> Delete(int id);
    Task<int> Update(ProductRequest product);
    Task<ProductRequest> GetById(int id);
}
