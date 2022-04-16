using CommerceTest.Application.Dtos;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IPedidoProdutoService
    {
        Task<IEnumerable<PedidoProdutoDto>> ObterTodosOsPedidoProdutos();
        Task<PedidoProdutoDto> ObterPedidosProdutosPorId(Guid id);
        Task<PedidoProdutoDto> SalvarRegistroDoPedidoProduto(PedidoProdutoDto pedidoProdutoDto);
        Task<PedidoProdutoDto> AlterarRegistroDoPedidoPedidosProduto(PedidoProdutoDto pedidoProdutoDto);
        Task<PedidoProdutoDto> DeletarRegistroDoPedidoPedidosProduto(Guid id);
        
    }
}
