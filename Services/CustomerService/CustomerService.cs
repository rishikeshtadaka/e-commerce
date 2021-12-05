using Aalgro.ECommerce.DataAccess.Repository;
using Aalgro.ECommerce.Domains;
using Aalgro.ECommerce.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Services.CustomerService
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository) : base(repository) { }
        public bool isValid(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
