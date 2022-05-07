using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Context;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Data.Repositories.Implementations
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
