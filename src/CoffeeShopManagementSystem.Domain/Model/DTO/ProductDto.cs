using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.Model.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}
