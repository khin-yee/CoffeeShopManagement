using Newtonsoft.Json;


namespace CoffeeShopManagementSystem.ApiControl
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T?> SendOneAsync<T>(string endpoint, string timeout, FormUrlEncodedContent content, HttpMethod method)
        {
            try
            {
                HttpRequestMessage req = new HttpRequestMessage(method, endpoint);
                req.Headers.TryAddWithoutValidation("Accept", "application/x-www-form-urlencoded");
                req.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
                req.Content = content;

                _httpClient.Timeout = TimeSpan.FromMilliseconds(TimeSpan.FromSeconds(Convert.ToDouble(timeout)).TotalMilliseconds);

                HttpResponseMessage res = await _httpClient.SendAsync(req);
                var responseRaw = await res.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<T>(responseRaw);

                return responseData;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {

                throw new TimeoutException();

            }
            catch (Exception ex)
            {
                throw new Exception();

            }
        }
        public async Task<List<T>?> SendAsync<T>(string endpoint, string timeout, FormUrlEncodedContent content, HttpMethod method)
        {
            try
            {
                HttpRequestMessage req = new HttpRequestMessage(method, endpoint);
                req.Headers.TryAddWithoutValidation("Accept", "application/x-www-form-urlencoded");
                req.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
                req.Content = content;

                _httpClient.Timeout = TimeSpan.FromMilliseconds(TimeSpan.FromSeconds(Convert.ToDouble(timeout)).TotalMilliseconds);

                HttpResponseMessage res = await _httpClient.SendAsync(req);
                var responseRaw = await res.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<T>>(responseRaw);

                return responseData;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {

                throw new TimeoutException();

            }
            catch (Exception ex)
            {
                throw new Exception();

            }
        }
    }
}
