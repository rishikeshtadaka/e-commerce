using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        ECommerceDbContext DBInstance { get; }
    }
}
