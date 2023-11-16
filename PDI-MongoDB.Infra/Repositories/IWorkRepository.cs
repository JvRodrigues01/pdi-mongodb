using PDI_MongoDB.Domain.Entities;

namespace PDI_MongoDB.Infra.Repositories
{
    public interface IWorkRepository
    {
        Task AddAsync(Work work);
        Task<Work> GetByIdAsync(Guid id);
        Task UpdateAsync(Work work);
        Task<IEnumerable<Work>> GetAllAsync();
    }
}
