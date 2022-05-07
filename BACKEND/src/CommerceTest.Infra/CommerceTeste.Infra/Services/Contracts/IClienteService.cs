using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> ObterTodosOsClientes();
        Task<IEnumerable<ClienteDto>> ObterTodosOsClientesComPedidos();
        Task<ClienteDto> ObterClientePorId(Guid id);
        Task<ClienteDto> ObterClientePorIdComPedido(Guid id);
        Task<ClienteDto> SavarRegistroDoCliente(ClienteDto clienteDto);
        Task<ClienteDto> AlterarRegistroDoCliente(ClienteDto clienteDto);
        Task<ClienteDto> DeletarRegistroDoCliente(Guid id);
    }
}
