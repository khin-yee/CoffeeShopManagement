using CoffeeShopManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.IRepo
{
    public  interface IRepo
    {
        Task<List<Product>> GetProduct();
        Task<User> GetUserByEmail(string name, string password);

    }
}
