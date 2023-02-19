using AB12.Domain.Base.Schema;

namespace AB12.Domain.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            InitializeProducts(context);
            InitializeOrders(context);
        }

        public static void InitializeProducts(AppDbContext context)
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

        public static void InitializeOrders(AppDbContext context)
        {
            // Look for any orders.
            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }

            var orders = new Order[]
            {
                new Order{ ClientName="Salah", Status=OrderStatus.New},
                new Order{ ClientName="Omer", Status=OrderStatus.InProgress},
                new Order{ ClientName="Ali", Status=OrderStatus.Completed},
                new Order{ ClientName="Mohhamed", Status=OrderStatus.New},
                new Order{ ClientName="Ahmed", Status=OrderStatus.InProgress},
                new Order{ ClientName="Kahled", Status=OrderStatus.Completed},
                new Order{ ClientName="Mazen", Status=OrderStatus.New},
                new Order{ ClientName="Mahmoud", Status=OrderStatus.InProgress},
            };

            context.Orders.AddRange(orders);

            context.SaveChanges();
        }
    }
}
