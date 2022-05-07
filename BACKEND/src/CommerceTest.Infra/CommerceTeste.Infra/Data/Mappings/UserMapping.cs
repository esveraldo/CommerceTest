using CommerceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasColumnType("varchar(40)")
                .IsRequired();
            builder.Property(x => x.Password)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.HasOne(c => c.Cliente)
                .WithOne(u => u.User)
                .HasForeignKey<Cliente>(c => c.UserId);
        }
    }
}
