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
                .HasColumnType("varchar(10)")
                .IsRequired();

            //builder.OwnsOne(x => x.Endereco);

            /*builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Rua)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Complemento)
                .HasColumnType("varchar(30)")
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
                .IsRequired();*/

            builder.OwnsOne(e => e.Endereco, x => {
                x.Property(p => p.Rua)
                .HasColumnType("varchar(100)")
                .HasColumnName("Rua")
                .HasDefaultValue("")
                .IsRequired();

                x.Property(p => p.Numero)
                .HasColumnType("varchar(10)")
                .HasColumnName("Numero")
                .HasDefaultValue("")
                .IsRequired();

                x.Property(p => p.Complemento)
                .HasColumnType("varchar(20)")
                .HasColumnName("Complemento")
                .HasDefaultValue("")
                .IsRequired();

                x.Property(p => p.Bairro)
                .HasColumnType("varchar(50)")
                .HasColumnName("Bairro")
                .HasDefaultValue("")
                .IsRequired();

                x.Property(p => p.Cidade)
                .HasColumnType("varchar(50)")
                .HasColumnName("Cidade")
                .HasDefaultValue("")
                .IsRequired();

                x.Property(p => p.Estado)
                .HasColumnType("varchar(50)")
                .HasColumnName("Estado")
                .HasDefaultValue("")
                .IsRequired();

                x.Property(p => p.Cep)
                .HasColumnType("varchar(15)")
                .HasColumnName("Cep")
                .HasDefaultValue("")
                .IsRequired();
            });

            builder.Property(x => x.Documento)
                .HasConversion(x => x.ToString(), x => (EDocumento)Enum.Parse(typeof(EDocumento), x))
                .HasColumnType("varchar(30)");

            builder.HasMany(p => p.Pedidos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
