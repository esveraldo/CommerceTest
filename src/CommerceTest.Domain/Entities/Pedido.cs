using CommerceTest.Domain.Entities.Base;
using CommerceTest.Domain.Entities.Enums;

namespace CommerceTest.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido(DateTime dataDoPedido, decimal valorTotal, EStatus status, string? observacoes, Guid pedidoId)
        {
            DataDoPedido = dataDoPedido;
            ValorTotal = valorTotal;
            Status = status;
            Observacoes = observacoes;
            PedidoId = pedidoId;    
        }

        public DateTime DataDoPedido { get; private set; }
        public decimal ValorTotal { get; private set; }
        public EStatus Status { get; private set; }
        public string? Observacoes { get; private set; }

        //EF
        public Pedido Pedidos { get; set; }
        public virtual Guid PedidoId { get; private set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }

    }
}
