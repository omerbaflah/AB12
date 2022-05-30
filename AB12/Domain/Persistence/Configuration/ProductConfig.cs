using AB12.Domain.Base.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AB12.Domain.Persistence.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(p => p.ID).HasMaxLength(255);

            builder.HasMany<OrderItem>(p => p.OrderItems)
                   .WithOne(oi => oi.Product);
        }
    }
}
