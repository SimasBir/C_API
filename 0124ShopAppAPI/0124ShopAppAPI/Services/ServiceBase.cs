using _0124ShopAppAPI.Data;
using _0124ShopAppAPI.Exceptions;
using _0124ShopAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Services
{
    public abstract class ServiceBase<T> where T : NamedEntity
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected ServiceBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var list = await _dbSet.ToListAsync();
            return list;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var item = await _dbSet.FirstOrDefaultAsync(t => t.Id == id);
            return item;
        }
        public async Task<int> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int entityId)
        {
            var entity = await GetByIdAsync(entityId);
            if (entity == null)
            {
                throw new IdNotFoundException("Id not found: ", entityId);
                //throw new ArgumentException($"Id {entityId} was not found");
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
