using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;

    public HttpService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    public async Task<T> Get<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        return await SendRequest<T>(request);
    }

    public Task<T> Post<T>(string uri, object value)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
        };
        return SendRequest<T>(request);
    }

    public async Task<T> Post<T>(string uri, MultipartFormDataContent formData)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = formData
        };
        return await SendRequest<T>(request);
    }

    public Task<T> Put<T>(string uri, object value)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, uri)
        {
            Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
        };
        return SendRequest<T>(request);
    }

    public Task Delete(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, uri);
        return SendRequest<int>(request);
    }

    private async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
        var user = await _localStorageService.GetItem<User>("user");
        var isApiUrl = !request.RequestUri.IsAbsoluteUri;
        if (user != null && isApiUrl)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", user.AuthData);
        }

        using var response = await _httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _navigationManager.NavigateTo("logout");
            return default;
        }

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode}, Details: {errorContent}");
        }

        if (typeof(T) == typeof(void))
        {
            return default;
        }

        try
        {
            var result = await response.Content.ReadFromJsonAsync<Reponse<T>>();
            return result.Data;
        }
        catch (Exception ex)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error reading response: {ex.Message}. Response content: {errorContent}");
        }
    }
}
