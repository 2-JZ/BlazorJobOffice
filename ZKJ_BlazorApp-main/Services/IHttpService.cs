namespace BlazorApp.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        //Task<T> Post<T>(string uri, MultipartFormDataContent formData);
        Task<T> Put<T>(string uri, object value);
        Task Delete(string uri);
        Task<T> PostAsync<T>(string url, object data);

    }
}