using Aalgro.ECommerce.DataAccess;
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

        private bool IsSuccessStatusCode(int statusCode)
        {
             return ((int)statusCode >= 200) && ((int)statusCode <= 299); 
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            IDbContext dbCtx = (IDbContext)context.HttpContext.RequestServices.GetService(typeof(IDbContext));
            var dbContext = dbCtx.GetDbContext();
            if (context.Exception != null || !IsSuccessStatusCode(context.HttpContext.Response.StatusCode))
            {
                dbContext.Database.RollbackTransaction();
                dbContext.Dispose();
                return;
            }

            dbContext.Database.CommitTransaction();
            dbContext.Dispose();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IDbContext dbCtx = (IDbContext)context.HttpContext.RequestServices.GetService(typeof(IDbContext));
            var dbContext = dbCtx.GetDbContext();
            dbContext.Database.BeginTransaction();
        }
    }
}
