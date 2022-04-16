using CommerceTest.Application.Dtos;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> ObterTodosOsClientes();
        Task<ClienteDto> ObterClientePorId(Guid id);
        Task<ClienteDto> SavarRegistroDoCliente(ClienteDto clienteDto);
        Task<ClienteDto> AlterarRegistroDoCliente(ClienteDto clienteDto);
        Task<ClienteDto> DeletarRegistroDoCliente(Guid id);
    }
}
