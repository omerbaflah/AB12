using AB12.Application.OrderItems;
using AB12.Domain.Base.Schema;
using AB12.Domain.Persistence;
using AB12.Infrastructure.Components.Common;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.Set<OrderItem>()
                .Include(x => x.Product)
                .Include(x => x.Order)
                .ToListAsync();
        }
    }
}
