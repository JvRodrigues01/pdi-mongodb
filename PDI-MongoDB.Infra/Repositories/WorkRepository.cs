using MongoDB.Driver;
using PDI_MongoDB.Domain.Entities;

namespace PDI_MongoDB.Infra.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly IMongoCollection<Work> _collection;
        public WorkRepository(IMongoDatabase mongoDatabase) 
        {
            _collection = mongoDatabase.GetCollection<Work>("works");
        }

        public async Task AddAsync(Work work)
        {
            await _collection.InsertOneAsync(work);
        }

        public async Task<Work> GetByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Work work)
        {
            await _collection.ReplaceOneAsync(x => x.Id == work.Id, work);
        }

        public async Task<IEnumerable<Work>> GetAllAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
