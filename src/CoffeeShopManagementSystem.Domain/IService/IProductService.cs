using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.IService
{
    public interface IProductService
    {
       Task<List<ProductDto>> GetProduct();
        Task<List<OrderDto>> GetOrder();
        Task<User> GetUserByEmail(string name, string password);
        bool AddProduct(ProductDto product);
        Response DeleteProduct(ProductDto productDto);
        Response CreateOrder(OrderDto order);
        Task<List<IngredientDTO>> GetIngredietns();


    }
}
