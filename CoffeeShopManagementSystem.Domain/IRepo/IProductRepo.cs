using CoffeeShopManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.IRepo
{
    public  interface IProductRepo
    {
        Task<List<Product>> GetProduct();
    }
}
