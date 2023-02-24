namespace BlazorApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<int> Create(Product product);
        Task<int> Delete(int Id);
        Task<int> Update(Product product);
        Task<Product> GetById(int Id);
    }
}