using CoffeeShopManagementSystem.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.IService
{
    public interface IInventoryManagementService
    {
       Task<List<ProductDto>> GetProduct();
    }
}
