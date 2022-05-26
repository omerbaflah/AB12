using AB12.Domain.Base.Common;

namespace AB12.Domain.Base.Schema
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
