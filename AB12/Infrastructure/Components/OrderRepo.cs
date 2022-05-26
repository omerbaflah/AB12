using AB12.Domain.Base.Schema;
using AB12.Domain.Persistence;
using AB12.Infrastructure.Components.Common;

namespace AB12.Infrastructure.Components
{
    public class ProductItemRepo : BaseRepo<Order>
    {
        private readonly AppDbContext _context;
        public ProductItemRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
