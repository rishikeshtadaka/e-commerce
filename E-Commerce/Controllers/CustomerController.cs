using Aalgro.ECommerce.Models;
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
    [Route("customers")]
    public class CustomerController : BaseController
    {
        private ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Transaction]
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            var list = await this.customerService.Get();
            return list;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(CustomerLoginModel customerLogin)
        {
            return Ok();
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult Registration(CustomerRegisterModel customerRegisterModel)
        {
            return Ok();
        }
    }
}
