using Aalgro.ECommerce.Domains;
using Aalgro.ECommerce.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Models.RequestModels
{
    public class CustomerRegisterModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public CustomerModel ConvertToCustomerModel()
        {
            return new CustomerModel
            {
                FirstName = this.FirstName
                                ,
                LastName = this.LastName
                                ,
                Email = this.Email
                                ,
                Mobile = this.Mobile
                                ,
                Password = this.Password//Encrypt password and store into DB.
            };
        }

    }
}
