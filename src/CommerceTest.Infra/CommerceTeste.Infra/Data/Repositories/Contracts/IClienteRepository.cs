using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;

namespace CommerceTeste.Infra.Data.Repositories.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterClientesComPedidos();
        Task<Cliente> ObterClienteComPedidoId(Guid id);
    }
}
