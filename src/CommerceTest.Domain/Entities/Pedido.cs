using CommerceTest.Domain.Entities.Base;
using CommerceTest.Domain.Entities.Enums;

namespace CommerceTest.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido(){}

        public Pedido(DateTime dataDoPedido, decimal valorTotal, EStatus status, string? observacoes)
        {
            DataDoPedido = dataDoPedido;
            ValorTotal = valorTotal;
            Status = status;
            Observacoes = observacoes;
        }

        public DateTime DataDoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public EStatus Status { get; set; }
        public string? Observacoes { get; set; }

        //EF
        public Cliente Cliente { get; set; }
        public virtual Guid ClienteId { get; private set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }

    }
}
