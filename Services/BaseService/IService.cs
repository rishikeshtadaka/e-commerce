using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Services.BaseService
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Get();
        T GetById(long Id);
        void Insert(T entity);
        void Delete(T entity);
        void Delete(long Id);
    }
}
