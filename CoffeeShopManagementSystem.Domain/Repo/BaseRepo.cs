using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Domain.Repo
{
    public abstract class BaseRepo<T>
    {
        protected readonly ApplicationDbContext _context;

        protected BaseRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<T> Get(int id)
        //{
        //    return _context.Set<T>().Find(id);
        //}

        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        //public async Task<IEnumerable<T>> GetAll(int skip, int take)
        //{
        //    return await _context.Set<T>().Skip(skip).Take(take).ToListAsync();
        //}

        //public async Task Add(T entity)
        //{
        //    await _context.Set<T>().AddAsync(entity);
        //}

        //public async Task Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        //public async Task Update(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //}

        //public async Task<int> Count()
        //{
        //    return await _context.Set<T>().CountAsync();
        //}
    }
}
