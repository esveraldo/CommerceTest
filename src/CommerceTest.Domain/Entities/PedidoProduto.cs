﻿using CommerceTest.Domain.Entities.Base;

namespace CommerceTest.Domain.Entities
{
    public class PedidoProduto : Entity
    {
        public PedidoProduto(){}

        public PedidoProduto(Guid pedidoId, Guid produtoId)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

        public Pedido? Pedido { get; set; }
        public Guid PedidoId { get; set; }
        public Produto? Produto { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
