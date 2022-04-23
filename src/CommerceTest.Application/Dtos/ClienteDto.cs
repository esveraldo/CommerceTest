using CommerceTest.Application.Dtos.Enums;
using CommerceTest.Application.Dtos.VOsDto;

namespace CommerceTest.Application.Dtos
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? DDD { get; set; }
        public string? Telefone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Endereco
        public EnderecoDto Endereco { get; set; }

        //Documento
        public EDocumentoDto DocumentoDto { get; set; }

        //EF
        public Guid UserId { get; set; }
    }
}
