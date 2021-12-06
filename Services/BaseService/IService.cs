using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Services.BaseService
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(long Id);
        Task Insert(T entity);
        Task Delete(T entity);
        Task Delete(long Id);
    }
}
