using AutoMapper;
using CommerceTeste.Infra.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Extensions
{
    public static class AutoMapperExtension 
    {
        public static void AddRegisterAutoMapper(this IServiceCollection service)
        {
            MapperConfiguration mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            service.AddSingleton(c => mapper.CreateMapper());
        }
    }
}
