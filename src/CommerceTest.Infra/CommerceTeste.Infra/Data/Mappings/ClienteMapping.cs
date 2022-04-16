using CommerceTest.Domain.Entities;
using CommerceTest.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerceTeste.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();
            builder.Property(x => x.DDD)
                .HasColumnType("varchar(2)")
                .IsRequired();
            builder.Property(x => x.Telefone)
                .HasColumnType("varchar(9)")
                .IsRequired();
            
            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Rua)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Bairro)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cidade)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Estado)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cep)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(x => x.Documento)
                .HasConversion(x => x.ToString(), x => (EDocumento)Enum.Parse(typeof(EDocumento), x))
                .HasColumnType("varchar(30)");

            builder.HasMany(p => p.Pedidos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
