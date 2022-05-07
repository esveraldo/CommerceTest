using CommerceTest.Domain.Entities;
using CommerceTest.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerceTeste.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey("Id");


            builder.Property(x => x.DataDoPedido)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.ValorTotal)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Status)
                .HasColumnType("varchar(10)")
                .HasConversion(x => x.ToString(), x => (EStatus)Enum.Parse(typeof(EStatus), x));
            builder.Property(x => x.Observacoes)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
