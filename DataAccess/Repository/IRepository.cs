using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        void Delete(T entity);
        Task<List<T>> GetAsync();
        Task SaveChangesAsync();
    }
}
