using Aalgro.ECommerce.Domains;
using System;

namespace ECommerce.Models
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static CustomerModel PrepareModel(Customer customer)
        {
            return new CustomerModel { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName };
        }

        public Customer ConvertToDomain()
        {
            return new Customer { Id=this.Id,FirstName=this.FirstName,LastName=this.LastName};
        }
    }
}
