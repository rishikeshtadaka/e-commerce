using Aalgro.ECommerce.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aalgro.ECommerce.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
