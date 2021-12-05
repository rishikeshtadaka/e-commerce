using Aalgro.ECommerce.Services.CustomerService;
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
        public IEnumerable<CustomerModel> Get()
        {
            var list = this.customerService.Get();
            return list;
        }
    }
}
