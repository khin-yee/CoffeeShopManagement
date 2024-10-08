using CoffeeShopManagementSystem.Domain.IRepo;
using CoffeeShopManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.Repo
{
    public class ProductRepo : IProductRepo
    {
        protected readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
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
    }
}
