using System;
using System.ComponentModel.DataAnnotations;

namespace Aalgro.ECommerce.Domains
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
