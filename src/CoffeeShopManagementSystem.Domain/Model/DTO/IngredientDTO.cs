﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.Model.DTO
{
    public  class IngredientDTO
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public string Unit { get; set; }
        public string Amount { get; set; }
    }
}
