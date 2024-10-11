using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using Newtonsoft.Json;

namespace CoffeeShopManagementSystem.ApiControl
{
    public class ApiCall:IApiCall
    {
        private readonly IHttpClientService _http;
        private readonly IHttpClientService _shttp;
        public ApiCall(IHttpClientService http, IHttpClientService shttp)
        {
            _http = http;
            _shttp = shttp;
        }
        public async Task<List<ProductDto>> GetProduct()
        {
            var res = await _http.SendAsync<ProductDto>("https://localhost:7055/Product", "100", null, HttpMethod.Get);
            return res;
        }
        public async Task<List<OrderDto>> GetOrder()
        {
            var res = await _http.SendAsync<OrderDto>("https://localhost:7055/Order", "100", null, HttpMethod.Get);
            return res;
        }
        public bool AddProduct(ProductDto product)
        {
            //public async Task<T?> SendJsonAsync<T>(string requestJson, string path, string timeout, HttpMethod httpMethod)

            var res =  _http.SendJsonAsync<bool>(JsonConvert.SerializeObject(product),"https://localhost:7055/AddProduct", "100",  HttpMethod.Post);            
            return true;
        }
        public Task<Response> AddOrder(OrderDto order)
        {
            //public async Task<T?> SendJsonAsync<T>(string requestJson, string path, string timeout, HttpMethod httpMethod)

            var res = _shttp.SendJsonAsync<Response>(JsonConvert.SerializeObject(order), "https://localhost:7055/AddOrder", "100", HttpMethod.Post);
            return res;
        }
        public Task<Response> DeleteProduct(ProductDto product)
        {
            var res =  _http.SendJsonAsync<Response>(JsonConvert.SerializeObject(product), "https://localhost:7055/Deleteroduct", "100", HttpMethod.Post);
            return res;
        }
        public async Task<User> GetAccountAuth(string name, string password)
        {
            var parameters = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("Name",name),
                                    new KeyValuePair<string, string>("Password", password)
                                };

            var encodedContent = new FormUrlEncodedContent(parameters);

            var res = await _http.SendOneAsync<User>("https://localhost:7055/AccValidate", "100", encodedContent, HttpMethod.Post);
            return res;
        }
    }
}
