using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.IRepo
{
    public  interface IRepo
    {
        bool AddProduct(ProductDto productDto);
        Task<List<Product>> GetProduct();
        Task<User> GetUserByEmail(string name, string password);
        Response DeleteProduct(ProductDto productDto);
        Task<Response> CreateOrder(OrderDto orderdto);
        Task<List<Order>> GetOrder();
        Task<List<Ingredients>> GetIngredients();


        Response CreateIngredient(IngredientDTO ingredientdto);
        Task<Response> DeleteProductByName(string name);
        Task<Response> DeleteOrderByName(string customername, string productname);
        Task<Response> DeleteIngredientByName(string name);


    }
}
