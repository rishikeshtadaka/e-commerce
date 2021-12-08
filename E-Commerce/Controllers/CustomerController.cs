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
        public async Task<IActionResult> Login(CustomerLoginModel customerLogin)
        {
            var isValid = await this.customerService.IsValid(customerLogin.Username, customerLogin.Password);
            if(isValid)
                return Ok();
            return Unauthorized();
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration(CustomerRegisterModel customerRegisterModel)
        {
            await this.customerService.Register(customerRegisterModel);
            return Created("",1);
        }
    }
}
