﻿using AutoMapper;
using CoffeeShopManagementSystem.Domain.IRepo;
using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.Repo
{
    public class Repository : IRepo.IRepo
    {
        protected readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<Product>> GetProduct()
        {
            try
            {
                var res = await _context.Product.OrderByDescending(p => p.Id).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var response =  _context.Add(product);
            _context.SaveChanges();
            return true;
        }
        
        public Response DeleteProduct(ProductDto productDto)
        {
            Response res = new Response();
            var product =_mapper.Map<Product>(productDto);
            var response =  _context.Remove(product);
            _context.SaveChanges();
            res.ErrorCode = "00";
            res.ErrorMessage = "Success";
            return  res;
        }
        public async Task<User>GetUserByEmail(string name, string password)
        {
            try
            {
                return await _context.User.FirstOrDefaultAsync(x => x.Name == name && x.Password == password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<User> GetIngredient(string name, string password)
        //{
        //    try
        //    {
        //        return await _context.User.FirstOrDefaultAsync(x => x.Name == name && x.Password == password);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<Response>DeleteProductByName(string name)
        {
            Response res = new Response()
            {
                ErrorCode = "00",
                ErrorMessage = "Success"
            };
            try
            {
                var product = await _context.Product.FirstOrDefaultAsync(x => x.Name == name );
                _context.Product.Remove(product);
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                res.ErrorCode = "01";
                res.ErrorMessage = ex.Message;
            }
            return res;
        }
        public async Task<Response> DeleteIngredientByName(string name)
        {
            Response res = new Response()
            {
                ErrorCode = "00",
                ErrorMessage = "Success"
            };
            try
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(x => x.Name == name);
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                res.ErrorCode = "01";
                res.ErrorMessage = ex.Message;
            }
            return res;
        }
        private async  Task<int> GetAmount(string name,int qty)
        {
            var product =await _context.Product.FirstOrDefaultAsync(x => x.Name == name);
            var price = product.Amount;
            var res = price * qty;
            return res;

        }
        public async Task<Response> CreateOrder(OrderDto orderdto)
        {
            Response res = new Response()
            {
                ErrorCode = "00", 
                ErrorMessage = "Success"
            };

            try
            {
                // Map the OrderDto to an Order entity
                var order = _mapper.Map<Order>(orderdto);
                var amount =await GetAmount(orderdto.ProductName, orderdto.Quality);
                order.TotalAmount = amount;
                // Find the product in the context using the product name
                var product = _context.Product.FirstOrDefault(p => p.Name == orderdto.ProductName);

                // Check if the product exists
                if (product == null)
                {
                    res.ErrorCode = "02"; // Error code for product not found
                    res.ErrorMessage = "Product not found.";
                    return res;
                }

                // Check if there is enough quantity available
                if (product.Quantity < 1) // Assuming Quantity is an int field
                {
                    res.ErrorCode = "03"; // Error code for insufficient quantity
                    res.ErrorMessage = "Insufficient product quantity.";
                    return res;
                }

                // Decrease the quantity of the product
                for (int i = 1; i <= orderdto.Quality; i++)
                {
                    product.Quantity--;
                }
                // Add the order to the context
                _context.Add(order);

                // Save changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                res.ErrorCode = "01";
                res.ErrorMessage = ex.Message;
            }

            return res;
        }

        public async Task<List<Order>> GetOrder()
        {
            try
            {
                return await _context.Order.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Ingredients>> GetIngredients()
        {
            try
            {
                var ingredients = await _context.Ingredients
                .ToListAsync();
                return ingredients;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Response CreateIngredient(IngredientDTO ingredientdto)
        {
            Response res = new Response()
            {
                ErrorCode = "00",
                ErrorMessage = "Success"
            };

            try
            {
                // Map the OrderDto to an Order entity
                var ingredient = _mapper.Map<Ingredients>(ingredientdto);

                _context.Add(ingredient);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                res.ErrorCode = "01";
                res.ErrorMessage = ex.Message;
            }

            return res;
        }
        public async Task<Response> DeleteOrderByName(string customername,string productname)
        {
            Response res = new Response()
            {
                ErrorCode = "00",
                ErrorMessage = "Success"
            };
            try
            {
                var order = await _context.Order.FirstOrDefaultAsync(x => x.CustomerName==customername && x.ProductName==productname);
                _context.Order.Remove(order);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                res.ErrorCode = "01";
                res.ErrorMessage = ex.Message;
            }
            return res;
        }

    }
}
