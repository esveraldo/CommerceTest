using CommerceTest.Domain.Entities;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IPedidoProdutoService
    {
        Task<IEnumerable<Pedido>> ObterTodosOsPedidosComProdutos();
        Task<IEnumerable<Produto>> ObterTodosOsProdutosComPedidos();
        Task<Produto> ObterPedidoProdutoPorProdutoId(Guid id);
        Task<Pedido> ObterPedidoProdutoPorPedidoId(Guid id);
        Task SalvarPedidoProduto(Guid pedidoId, Guid produtoId);
    }
}
