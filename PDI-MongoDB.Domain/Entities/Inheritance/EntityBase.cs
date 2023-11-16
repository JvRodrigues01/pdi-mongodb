namespace PDI_MongoDB.Domain.Entities.Inheritance
{
    public interface IEntityBase
    {
        public Guid Id { get; set; }
        public bool IsEnabled { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
    public class EntityBase
    {
        public Guid Id { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
