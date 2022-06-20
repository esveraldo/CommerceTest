using CommerceTest.Application.Dtos.Enums;
using CommerceTest.Application.Dtos.VOsDto;
using System.ComponentModel.DataAnnotations;

namespace CommerceTest.Application.Dtos
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? DDD { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Telefone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Endereco
        public EnderecoDto Endereco { get; set; }

        //Documento
        public EDocumentoDto Documento { get; set; }

        //EF
        public Guid UserId { get; set; }
    }
}
