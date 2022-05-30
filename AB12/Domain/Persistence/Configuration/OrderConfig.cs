using AB12.Domain.Base.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB12.Domain.Persistence.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.Property(p => p.ID).HasMaxLength(255);
            
            builder.HasMany<OrderItem>(o => o.OrderItems)
                   .WithOne(oi => oi.Order);
        }
    }
}
