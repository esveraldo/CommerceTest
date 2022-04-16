using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTest.Application.Dtos
{
    public class PedidoProdutoDto
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
