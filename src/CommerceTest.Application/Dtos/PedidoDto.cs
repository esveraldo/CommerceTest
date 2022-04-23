using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommerceTest.Application.Dtos.Enums;

namespace CommerceTest.Application.Dtos
{
    public class PedidoDto
    {
        public DateTime DataDoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public EStatusDto Status { get; set; }
        public string? Observacoes { get; set; }
        public Guid ClienteId { get; set; }
    }
}
