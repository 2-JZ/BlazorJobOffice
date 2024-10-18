using BlazorApp.Models;
using BlazorApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductsService : IProductsService
{
    private IHttpService _httpService;

    public ProductsService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public Task<IEnumerable<ProductRequest>> GetAll()
    {
        return _httpService.Get<IEnumerable<ProductRequest>>("/Products");
    }

    public Task<IEnumerable<ProductRequest>> GetByCategory(int categoryId)
    {
        return _httpService.Get<IEnumerable<ProductRequest>>($"/Products/byCategory/{categoryId}");
    }

    public async Task<int> Create(ProductRequest product)
    {
        var result = await _httpService.Post<ProductRequest>("Products/addProduct", product);
        return result.Id;
    }

    public async Task<int> Delete(int id)
    {
        await _httpService.Delete($"/Products/{id}");
        return id;
    }

    public async Task<int> Update(ProductRequest product)
    {
        var result = await _httpService.Put<ProductRequest>($"/Products/{product.Id}", product);
        return result.Id;
    }

    public Task<ProductRequest> GetById(int id)
    {
        return _httpService.Get<ProductRequest>($"/Products/{id}");
    }
}
