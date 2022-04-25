using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Context;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CommerceTeste.Infra.Data.Repositories.Implementations
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Cliente> ObterClienteComPedidoId(Guid id)
        {
            var result = _context.Clientes.Include(p => p.Pedidos).AsNoTracking().Where(x => x.Id == id).FirstOrDefault(); ;
            return result;
        }

        public async Task<IEnumerable<Cliente>> ObterClientesComPedidos()
        {
            return await _context.Clientes.Include(p => p.Pedidos).AsNoTracking().ToListAsync();
        }
    }
}
