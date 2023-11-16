using PDI_MongoDB.Domain.Entities.Inheritance;
using PDI_MongoDB.Domain.Enums;

namespace PDI_MongoDB.Domain.Entities
{
    public class UserStory : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserStoryStatusEnum Status { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
