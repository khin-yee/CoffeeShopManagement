using Newtonsoft.Json;
using System.Text;


namespace CoffeeShopManagementSystem.ApiControl
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T?> SendJsonAsync<T>(string requestJson, string path, string timeout, HttpMethod httpMethod)
        {
            try
            {
                HttpRequestMessage req = new HttpRequestMessage(httpMethod, path);
                req.Headers.TryAddWithoutValidation("Accept", "application/json");

                // Set the request content to JSON
                req.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                // Set the timeout
                _httpClient.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));

                // Send the request
                HttpResponseMessage res = await _httpClient.SendAsync(req);

                // Check for a successful response
                res.EnsureSuccessStatusCode();

                // Read the response as a string
                var responseRaw = await res.Content.ReadAsStringAsync();

                // Deserialize the response to the expected type
                var responseData = JsonConvert.DeserializeObject<T>(responseRaw);

                return responseData;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                // Handle timeout exceptions
                throw new TimeoutException("Request timed out.", ex);
            }
            catch (HttpRequestException httpEx)
            {
                // Handle HTTP request exceptions
                throw new Exception($"HTTP request failed: {httpEx.Message}", httpEx);
            }
            catch (Exception ex)
            {
                // Log or handle general exceptions
                throw new Exception($"An error occurred: {ex.Message}", ex);
            }
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
