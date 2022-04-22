using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.Services.Implamentations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient<IClienteService, ClienteService>();
            service.AddTransient<IPedidoProdutoService, PedidoProdutoService>();
            service.AddTransient<IPedidoService, PedidoService>();
            service.AddTransient<IProdutoService, ProdutoService>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}
