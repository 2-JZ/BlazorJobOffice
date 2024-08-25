using BlazorApp.Models;
using BlazorApp.Services;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

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
        using var httpClient = new HttpClient();
        var categoryJson = JsonSerializer.Serialize(category);
        var categoryContent = new StringContent(categoryJson, Encoding.UTF8, "application/json");

        using var formData = new MultipartFormDataContent
        {
            { categoryContent, "category" }
        };

        var response = await httpClient.PostAsync("your_api_endpoint/Category/addCategory", formData);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Category>();
            return result.Id;
        }

        throw new Exception("Error creating category.");
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
