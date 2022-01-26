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

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id); 
        }
        public int Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            if (entity == null)
            {
                throw new IdNotFoundException("Id not found: ", entityId);
                //throw new ArgumentException($"Id {entityId} was not found");
            }
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
