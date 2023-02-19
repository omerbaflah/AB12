using AB12.Domain.Base.Schema;
using AB12.Domain.Persistence;
using AB12.Infrastructure.Components.Common;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace AB12.Infrastructure.Components
{
    [ScopedService]
    public class OrderItemRepo : BaseRepo<OrderItem>
    {
        private readonly AppDbContext _context;
        public OrderItemRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
