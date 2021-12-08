using Aalgro.ECommerce.DataAccess.Repository;
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
    public class CustomerService : Service<Customer,CustomerModel>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository) : base(repository) { }
        public async Task<bool> IsValid(string username, string password)
        {
            var list = await this.GetEntitiesAsync(t => t.UserName == username && t.Password == password);
            return list.Any();
        }

        public async Task Register(CustomerRegisterModel customerRegisterModel)
        {
           await this.Insert(customerRegisterModel.ConvertToCustomerModel());
        }

        public async override Task<IEnumerable<CustomerModel>> Get()
        {
            var list = await this.GetEntitiesAsync();
            return list.Select(t => CustomerModel.PrepareModel(t));
        }

        public async override Task Update(CustomerModel entity)
        {
            var customer = await this.GetEntityByIdAsync(entity.Id);
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            await this.SaveChangesAsync();
        }

        
        public async override Task<CustomerModel> GetById(long Id)
        {
            var entity = await this.GetEntityByIdAsync(Id);
            return CustomerModel.PrepareModel(entity);
        }

        public async override Task Insert(CustomerModel entity)
        {            
            await this.InsertEntity(entity.ConvertToDomain());
        }

        public async override Task Delete(CustomerModel entity)
        {
            await this.DeleteEntityAsync(entity.ConvertToDomain());
        }

        public async override Task Delete(long Id)
        {
            await this.DeleteEntityAsync(Id);
        }
    }
}
