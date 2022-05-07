using CommerceTest.Domain.Entities.Base;

namespace CommerceTest.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(string? nome, string? descricao, decimal? preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? Preco { get; private set; }

        //EF
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }
    }
}
