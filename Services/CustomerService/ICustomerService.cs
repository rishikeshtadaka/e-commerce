using Aalgro.ECommerce.Domains;
using Aalgro.ECommerce.Models.RequestModels;
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
        Task<bool> IsValid(string username, string password);

        Task Register(CustomerRegisterModel customerRegisterModel);
    }
}
