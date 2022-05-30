using AB12.Domain.Base.Common;

namespace AB12.Domain.Base.Schema
{
    public class Order : AuditableEntity
    {
        public string ClientName { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public enum OrderStatus
    {
        New,
        InProgress,
        Completed
    }
}
