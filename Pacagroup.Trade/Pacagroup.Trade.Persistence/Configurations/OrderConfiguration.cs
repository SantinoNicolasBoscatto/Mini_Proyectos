using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasPrecision(9, 0)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Symbol)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Side)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.Type)
               .HasMaxLength(1)
               .IsRequired();

            builder.Property(x => x.TrasactionTime)
                .IsRequired();

            builder.Property(x => x.Quanty)
                .HasPrecision(9, 0)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(9, 4)
                .IsRequired();
        }
    }
}
