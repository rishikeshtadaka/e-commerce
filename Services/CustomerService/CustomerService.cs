using Aalgro.ECommerce.DataAccess.Repository;
using Aalgro.ECommerce.Domains;
using Aalgro.ECommerce.Services.BaseService;
using ECommerce.Models;
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
        public bool isValid(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<CustomerModel> Get()
        {
            return this.GetEntities().Select(t => CustomerModel.PrepareModel(t));
        }

        public override void Update(CustomerModel entity)
        {
            var customer = this.GetEntityById(entity.Id);
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            this.SaveChanges();
        }

        
        public override CustomerModel GetById(long Id)
        {
            return CustomerModel.PrepareModel(this.GetEntityById(Id));
        }

        public override void Insert(CustomerModel entity)
        {
            this.InsertEntity(entity.ConvertToDomain());
        }

        public override void Delete(CustomerModel entity)
        {
            this.DeleteEntity(entity.ConvertToDomain());
        }

        public override void Delete(long Id)
        {
            this.DeleteEntity(Id);
        }
    }
}
