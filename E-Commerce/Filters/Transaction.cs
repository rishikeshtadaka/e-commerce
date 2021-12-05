using DataAccess;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Filters
{
    public class Transaction : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ECommerceDbContext dbContext = (ECommerceDbContext)context.HttpContext.RequestServices.GetService(typeof(ECommerceDbContext));            
            dbContext.Database.CommitTransaction();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ECommerceDbContext dbContext =(ECommerceDbContext)context.HttpContext.RequestServices.GetService(typeof(ECommerceDbContext));
            dbContext.Database.BeginTransaction();
        }
    }
}
