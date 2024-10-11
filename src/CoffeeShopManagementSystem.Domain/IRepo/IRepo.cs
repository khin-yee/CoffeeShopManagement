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
        Response CreateOrder(OrderDto orderdto);

    }
}
