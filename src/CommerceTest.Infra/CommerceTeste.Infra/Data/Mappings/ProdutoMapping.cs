using CommerceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerceTeste.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Preco)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
