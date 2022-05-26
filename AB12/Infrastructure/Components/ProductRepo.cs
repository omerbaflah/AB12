using AB12.Domain.Base.Schema;
using AB12.Domain.Persistence;
using AB12.Infrastructure.Components.Common;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace AB12.Infrastructure.Components
{
    [ScopedService]
    public class ProductRepo : BaseRepo<Product>
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
