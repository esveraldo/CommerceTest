using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommerceTest.Application.Dtos.Enums;

namespace CommerceTest.Application.Dtos
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataDoPedido { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal ValorTotal { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public EStatusDto Status { get; set; }
        public string? Observacoes { get; set; }
        public Guid ClienteId { get; set; }
    }
}
