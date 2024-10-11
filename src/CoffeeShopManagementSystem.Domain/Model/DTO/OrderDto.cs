using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.Model.DTO
{
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductName { get; set; }
        public int Quality { get; set; }
        public string OrderDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
