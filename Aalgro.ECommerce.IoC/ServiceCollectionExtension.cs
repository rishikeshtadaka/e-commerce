using Aalgro.ECommerce.DataAccess;
using Aalgro.ECommerce.DataAccess.Repository;
using Aalgro.ECommerce.Services.CustomerService;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aalgro.ECommerce.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDbContext, ECommerceDbContext>();
        }
    }
}
