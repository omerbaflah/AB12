using AB12.Domain.Base.Common;

namespace AB12.Domain.Base.Schema
{
    public class OrderItem : AuditableEntity
    {
        public string ProductID { get; set; }
        public string OrderID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
