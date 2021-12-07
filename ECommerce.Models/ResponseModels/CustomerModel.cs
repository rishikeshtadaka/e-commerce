using Aalgro.ECommerce.Domains;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aalgro.ECommerce.Models.ResponseModels
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public static CustomerModel PrepareModel(Customer customer)
        {
            return new CustomerModel { Id = customer.Id
                                    , FirstName = customer.FirstName
                                    , LastName = customer.LastName 
                                    , Email=customer.Email
                                    , Mobile=customer.Mobile
                                    , Password=customer.Password
                                    };
        }

        public Customer ConvertToDomain()
        {
            return new Customer { Id=this.Id
                                ,FirstName=this.FirstName
                                ,LastName=this.LastName
                                , Email=this.Email
                                , Mobile=this.Mobile
                                , Password=this.Password
                                };
        }
    }
}
