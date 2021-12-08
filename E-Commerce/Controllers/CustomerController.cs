using Aalgro.ECommerce.Models;
using Aalgro.ECommerce.Models.RequestModels;
using Aalgro.ECommerce.Models.ResponseModels;
using Aalgro.ECommerce.Services.CustomerService;
using E_Commerce.Filters;
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
        public async Task<ActionResult<IEnumerable<CustomerModel>>> Get()
        {
            var list = await this.customerService.Get();
            return Ok(list);
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
            return Created("",1);
        }
    }
}
