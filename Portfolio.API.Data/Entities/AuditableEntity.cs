namespace Portfolio.API.Data.Entities
{
    public abstract class AuditableEntity
    {
        public required DateTime CreatedAt { get; set; }
        public required User CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
