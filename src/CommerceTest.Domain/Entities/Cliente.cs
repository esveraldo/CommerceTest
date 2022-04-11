using CommerceTest.Domain.Entities.Base;
using CommerceTest.Domain.Entities.Enums;
using CommerceTest.Domain.Entities.VOs;

namespace CommerceTest.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string? nome, string? ddd, string? telefone, Endereco? endereco, EDocumento documento, Guid userId)
        {
            Nome = nome;
            DDD = ddd;
            Telefone = telefone;
            Endereco = endereco;
            Documento = documento;
            UserId = userId;
        }

        public string? Nome { get; private set; }
        public string? DDD { get; private set; }
        public string? Telefone { get; private set; }
        public Endereco? Endereco { get; private set; }
        public  EDocumento Documento { get; private set; }

        //EF
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual User User { get; set; }
        public virtual Guid UserId { get; private set; }
    }
}
