using CommerceTest.Domain.Entities.Enums;
using CommerceTest.Domain.Entities.VOs;

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
        public Endereco Endereco { get; set; }

        //Documento
        public EDocumento Documento { get; set; }

        //EF
        public Guid UserId { get; set; }
    }
}
