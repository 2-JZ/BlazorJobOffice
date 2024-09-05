using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class CategoriesService : ICategoriesService
{
    private readonly IHttpService _httpService;

    public CategoriesService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public Task<IEnumerable<Category>> GetAll()
    {
        return _httpService.Get<IEnumerable<Category>>("/Category");
    }

    public async Task<int> CreateCategory(Category category)
    {
        var result = await _httpService.Post<Category>("Category/AddCategory", category);
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
