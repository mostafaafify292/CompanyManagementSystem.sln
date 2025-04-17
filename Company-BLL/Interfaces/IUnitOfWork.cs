using Company_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public int Complete();
        public IGenericRepository<T> Repository<T>() where T : ModelBase;
    }
}
