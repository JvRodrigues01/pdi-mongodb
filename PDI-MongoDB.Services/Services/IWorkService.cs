using PDI_MongoDB.Domain.Entities;

namespace PDI_MongoDB.Services.Services
{
    public interface IWorkService
    {
        Task<Work> AddAsync(Work work);
        Task<Work> GetByIdAsync(Guid id);
        Task<Work> UpdateAsync(Work work);
        Task<IEnumerable<Work>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
