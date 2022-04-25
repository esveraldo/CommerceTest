using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTest.Application.Dtos
{
    public class ProdutoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal? Preco { get; set; }
    }
}
