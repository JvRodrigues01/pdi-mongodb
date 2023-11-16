using MongoDB.Bson;
using MongoDB.Driver;
using PDI_MongoDB.Domain.Entities;

namespace PDI_MongoDB.Infra.Repositories
{
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly IMongoCollection<UserStory> _collection;
        public UserStoryRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<UserStory>("UserStories");
        }

        public async Task AddAsync(UserStory userStory)
        {
            await _collection.InsertOneAsync(userStory);
        }

        public async Task<UserStory> GetByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(UserStory userStory)
        {
            await _collection.ReplaceOneAsync(x => x.Id == userStory.Id, userStory);
        }

        public async Task<IEnumerable<UserStory>> GetAllAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$lookup",
                    new BsonDocument
                    {
                        { "from", "Works" },
                        { "localField", "_id" },
                        { "foreignField", "UserStoryId" },
                        { "as", "Works" }
                    })
            };

            var cursor = await _collection.AggregateAsync<UserStory>(pipeline);

            return await cursor.ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
