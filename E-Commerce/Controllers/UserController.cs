using Aalgro.ECommerce.Services.CustomerService;
using E_Commerce.Filters;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private ICustomerService customerService;
        public UserController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Transaction]
        public IEnumerable<CustomerModel> Get()
        {
            this.customerService.Insert(new CustomerModel { FirstName = "f1", LastName = "l1" });
            var list = this.customerService.Get();
            return list;
        }
    }
}
