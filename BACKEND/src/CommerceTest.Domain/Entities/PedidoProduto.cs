namespace CommerceTest.Domain.Entities
{
    public class PedidoProduto
    {
        public PedidoProduto(Guid pedidoId, Guid produtoId)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public Pedido Pedidos { get; set; }
        public Produto Produtos { get; set; }
    }
}
