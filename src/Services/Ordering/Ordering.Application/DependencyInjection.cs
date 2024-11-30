using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services) 
        {
            //services.AddMediatR(cfg => {
            //    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //});

            return services;
        }
    }
}
