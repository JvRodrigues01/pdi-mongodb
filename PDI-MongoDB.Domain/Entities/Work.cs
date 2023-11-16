using PDI_MongoDB.Domain.Entities.Inheritance;

namespace PDI_MongoDB.Domain.Entities
{
    public class Work : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
