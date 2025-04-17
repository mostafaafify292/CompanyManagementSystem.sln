using Company_BLL.Interfaces;
using Company_DAL.Data;
using Company_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee))
            {
                return await _dbContext.Set<Employee>().Include(e=>e.Department).AsNoTracking().ToListAsync() as IEnumerable<T>;
            }
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public  IQueryable<T> SearchByNameAsync(string name)
        {
            if (typeof(T)==typeof(Employee))
            {
                return (IQueryable<T>) _dbContext.employee.Where(e => e.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                return (IQueryable<T>) _dbContext.department.Where(e => e.Name.ToLower().Contains(name.ToLower()));
            }

        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
