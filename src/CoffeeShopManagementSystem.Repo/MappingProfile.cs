﻿using AutoMapper;
using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Service
{
    public  class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Order,OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Ingredients, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredients>();
        }
    }
}
