using CommerceTest.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> ObterTodosOsPedidos();
        Task<PedidoDto> ObterPedidoPorId(Guid id);
        Task<PedidoDto> SalvarRegistroDoPedido(PedidoDto pedidoDto);
        Task<PedidoDto> AlterarRegistroDoPedido(PedidoDto pedidoDto);
        Task<PedidoDto> DeletarRegistroDoPedido(Guid id);
        
    }
}
