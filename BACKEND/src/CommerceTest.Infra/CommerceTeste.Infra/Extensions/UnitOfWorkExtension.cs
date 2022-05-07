using CommerceTeste.Infra.UoW.Contracts;
using CommerceTeste.Infra.UoW.Implementatios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Extensions
{
    public static class UnitOfWorkExtension
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
