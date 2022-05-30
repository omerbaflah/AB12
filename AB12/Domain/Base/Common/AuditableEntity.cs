namespace AB12.Domain.Base.Common
{
    public abstract class AuditableEntity
    {
        // uuid
        public string ID { get; set; }
        public AuditableEntity()
        {
            ID = Guid.NewGuid().ToString().Replace("-", "");
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
