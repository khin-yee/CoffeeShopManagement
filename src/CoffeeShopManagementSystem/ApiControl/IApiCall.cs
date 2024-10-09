using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;

namespace CoffeeShopManagementSystem.ApiControl
{
    public interface IApiCall
    {
       Task<List<ProductDto>> GetProduct();
       bool AddProduct(ProductDto product);

       Task<User> GetAccountAuth(string username, string password);

    }
}
