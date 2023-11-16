using System.ComponentModel;

namespace PDI_MongoDB.Domain.Enums
{
    public enum UserStoryStatusEnum
    {
        [Description("Nova")]
        NotStarted = 1,

        [Description("Em andamento")]
        InProgress = 2,

        [Description("Completa")]
        Completed = 3
    }
}
