using PDI_MongoDB.Domain.Entities;

namespace PDI_MongoDB.Services.Services
{
    public interface IUserStoryService
    {
        Task<UserStory> AddAsync(UserStory work);
        Task<UserStory> GetByIdAsync(Guid id);
        Task<UserStory> UpdateAsync(UserStory work);
        Task<IEnumerable<UserStory>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
