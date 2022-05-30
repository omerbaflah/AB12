using AB12.Domain.Base.Schema;

namespace AB12.Domain.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{ Name="MacBook Pro", Price=1200.00m, Description="Apple's latest laptop", Quantity=10},
                new Product{ Name="iPhone", Price=800.00m, Description="Apple's latest smartphone", Quantity=30},
                new Product{ Name="iPad", Price=700.00m, Description="Apple's latest tablet", Quantity=40},
                new Product{ Name="iPod", Price=100.00m, Description="Apple's latest portable media player", Quantity=50},
                new Product{ Name="iMac", Price=1500.00m, Description="Apple's latest desktop computer", Quantity=20},
                new Product{ Name="Mac Mini", Price=800.00m, Description="Apple's latest desktop computer", Quantity=10},
                new Product{ Name="Mac Pro", Price=2000.00m, Description="Apple's latest desktop computer", Quantity=5},
                new Product{ Name="MacBook Air", Price=1200.00m, Description="Apple's latest laptop", Quantity=10},
            };

            context.Products.AddRange(products);
            
            context.SaveChanges();
        }
    }
}
