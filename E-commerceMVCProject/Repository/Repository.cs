using E_commerceMVCProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_commerceMVCProject.Models;
using System.Linq.Expressions;
using System.Linq;

namespace E_commerceMVCProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IdentityDbContext<ApplicationUser> _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EComEntity context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        
        public T GetById(int id) 
        {
            return _dbSet.Find(id);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            T entityToDelete = GetById(id);
            if(entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                Save();
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
