using CommerceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerceTeste.Infra.Data.Mappings
{
    public class PedidoProdutoMapping : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.HasKey(x => new {x.PedidoId, x.ProdutoId});

            builder.Property(x => x.PedidoId)
                .IsRequired();

            builder.Property(x => x.ProdutoId)
                .IsRequired();
        }
    }
}
