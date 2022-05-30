using AB12.Domain.Base.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB12.Domain.Persistence.Configuration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.Property(p => p.ID).HasMaxLength(255);

            builder.HasOne<Product>(i => i.Product)
                .WithMany(p => p.OrderItems);

            builder.HasOne<Order>(i => i.Order)
                .WithMany(o => o.OrderItems);
        }
    }
}
