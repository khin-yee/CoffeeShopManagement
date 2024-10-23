using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;

namespace CoffeeShopManagementSystem.ApiControl
{
    public interface IApiCall
    {
       Task<List<ProductDto>> GetProduct();
        Task<List<OrderDto>> GetOrder();
        Task<List<IngredientDTO>> GetIngredient();

        bool AddProduct(ProductDto product);
        Task<Response> AddOrder(OrderDto order);

        Task<Response> DeleteProduct(string productname);
        Task<Response> DeleteIngredient(string name);

        Task<User> GetAccountAuth(string username, string password);

       Task<Response> AddIngredient(IngredientDTO ingredient);
        Task<Response> DeleteOrder(string customername, string productname);


    }
}
