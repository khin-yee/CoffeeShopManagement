using AutoMapper;
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
                return await _context.Product.ToListAsync();
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

        public  Response CreateOrder(OrderDto orderdto)
        {
            Response res = new Response()
            {
                ErrorCode = "00",
                ErrorMessage = "Success"
            };
            try
            {
                var order = _mapper.Map<Order>(orderdto);
                var response =  _context.Add(order);
                _context.SaveChanges();

                
            }
            catch(Exception ex)
            {
                res.ErrorCode = "01";
                res.ErrorMessage = ex.Message;
                
            }
            return res;
        }
    }
}
