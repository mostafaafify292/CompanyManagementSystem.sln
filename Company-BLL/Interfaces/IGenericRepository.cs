using Company_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Interfaces
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public IQueryable<T> SearchByNameAsync(string name);
    }
}
