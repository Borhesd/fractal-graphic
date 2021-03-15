using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace UIApp.Data
{
    public abstract class ClientAPI
    {
        protected readonly HttpClient _http;
        protected readonly string _apiAddress;

        protected ClientAPI(string apiAddress, HttpClient http)
        {
            _apiAddress = apiAddress;
            _http = http;
        }

        protected async Task<TReturn> GetAsync<TReturn>(string relativeUrl)
        {
            HttpResponseMessage res = await _http.GetAsync($"{_apiAddress}/{relativeUrl}");
            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<TReturn>();
            }
            else
            {
                string msg = await res.Content.ReadAsStringAsync();
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        protected async Task<TReturn> PostAsync<TReturn, TRequest>(string relativeUrl, TRequest request)
        {
            HttpResponseMessage res = await _http.PostAsJsonAsync<TRequest>($"{_apiAddress}/{relativeUrl}", request);
            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<TReturn>();
            }
            else
            {
                string msg = await res.Content.ReadAsStringAsync();
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }
    }
}
