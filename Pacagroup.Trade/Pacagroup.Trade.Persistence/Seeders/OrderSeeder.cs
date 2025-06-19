using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Persistence.Seeders
{
    public class OrderSeeder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order
            {
                Id = 1,
                Symbol = "META",
                Side = Domain.Enums.OrderSide.BUY,
                TrasactionTime = DateTime.Now,
                Quanty = 1000,
                Type = Domain.Enums.OrderType.LIMIT,
                Price = 522.5M
            },
            new Order
            {
                Id = 2,
                Symbol = "MSFT",
                Side = Domain.Enums.OrderSide.BUY,
                TrasactionTime = DateTime.Now,
                Quanty = 300,
                Type = Domain.Enums.OrderType.LIMIT,
                Price = 424.30M
            });
        }
    }
}
