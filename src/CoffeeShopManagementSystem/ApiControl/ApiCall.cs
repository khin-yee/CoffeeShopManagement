using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;

namespace CoffeeShopManagementSystem.ApiControl
{
    public class ApiCall:IApiCall
    {
        private readonly IHttpClientService _http;
        public ApiCall(IHttpClientService http)
        {
            _http = http;
        }
        public async Task<List<ProductDto>> GetProduct()
        {
            var res = await _http.SendAsync<ProductDto>("https://localhost:7055/Product", "100", null, HttpMethod.Get);
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
