﻿using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ProductsService : IProductsService
    {
        private IHttpService _httpService;

        public ProductsService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return _httpService.Get<IEnumerable<Product>>("/Products");
        }

        public async Task<int> Create(Product product)
        {
            var result = await _httpService.Post<Product>("Products/addProduct", product);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"/Products/{id}");
            return id;
        }

        public async Task<int> Update(Product product)
        {
            var result = await _httpService.Put<Product>($"/Products/{product.Id}", product);
            return result.Id;
        }

        public Task<Product> GetById(int id)
        {
            return _httpService.Get<Product>($"/Products/{id}");
        }
    }
}