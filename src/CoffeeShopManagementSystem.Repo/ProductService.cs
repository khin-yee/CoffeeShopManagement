﻿using AutoMapper;
using CoffeeShopManagementSystem.Domain.IRepo;
using CoffeeShopManagementSystem.Domain.IService;
using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Service
{
    public class ProductService:IProductService
    {
        private readonly IRepo _productrepo;
        private readonly IMapper _mapper;

        public ProductService(IRepo productrepo, IMapper mapper)
        {
            _productrepo = productrepo;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> GetProduct()
        {
            var res = await  _productrepo.GetProduct();
            try
            {
               
                var response = _mapper.Map<List<ProductDto>>(res);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddProduct(ProductDto product)
        {
            return  _productrepo.AddProduct(product);
        }
        public async Task<User> GetUserByEmail(string name,string password)
        {
            return await _productrepo.GetUserByEmail(name, password);
        }
        public async Task<Response> DeleteProductByEmail(string name)
        {
            return await _productrepo.DeleteProductByName(name);
        }
        public async Task<Response> DeleteIngredientByName(string name)
        {
            return await _productrepo.DeleteIngredientByName(name);
        }
        public Response DeleteProduct(ProductDto productDto)
        {
            return  _productrepo.DeleteProduct(productDto);
        }

        public Task<Response> CreateOrder(OrderDto order)
        {
            return _productrepo.CreateOrder(order);
        }
        public async Task<List<OrderDto>> GetOrder()
        {
            var res = await _productrepo.GetOrder();
            try
            {

                var response = _mapper.Map<List<OrderDto>>(res);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<IngredientDTO>> GetIngredient()
        {
            var res = await _productrepo.GetIngredients();
            try
            {

                var response = _mapper.Map<List<IngredientDTO>>(res);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Response CreateIngredient(IngredientDTO ingredients)
        {
            return _productrepo.CreateIngredient(ingredients);
        }

        public async Task<Response> DeleteOrderByName(string customername,string prouctname)
        {
            return await _productrepo.DeleteOrderByName(customername,prouctname);
        }
    }
}
