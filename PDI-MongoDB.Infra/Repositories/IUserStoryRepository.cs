using PDI_MongoDB.Domain.Entities;

namespace PDI_MongoDB.Infra.Repositories
{
    public interface IUserStoryRepository
    {
        Task AddAsync(UserStory userStory);
        Task<UserStory> GetByIdAsync(Guid id);
        Task UpdateAsync(UserStory userStory);
        Task<IEnumerable<UserStory>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
