namespace AB12.Domain.Base.Common
{
    public class AuditableEntity
    {
        // uuid
        public string Id { get; set; }
        public AuditableEntity()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "");
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
