using AutoMapper;
using CoffeeShopManagementSystem.Domain.IRepo;
using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using Microsoft.EntityFrameworkCore;
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
    }
}
