using Aalgro.ECommerce.Domains;
using Aalgro.ECommerce.Models.ResponseModels;
using Aalgro.ECommerce.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Services.CustomerService
{
    public interface ICustomerService : IService<CustomerModel>
    {
        bool isValid(string username, string password);
    }
}
