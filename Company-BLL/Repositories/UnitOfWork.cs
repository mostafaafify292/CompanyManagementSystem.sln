using Company_BLL.Interfaces;
using Company_DAL.Data;
using Company_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private Hashtable _Hashtable;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _Hashtable = new Hashtable();
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
           _dbContext.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : ModelBase
        {
            var key = typeof(T).Name;
            if (!_Hashtable.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_dbContext);
                _Hashtable.Add(key, repository);
            }
            return _Hashtable[key] as IGenericRepository<T>;

        }
    }
}
