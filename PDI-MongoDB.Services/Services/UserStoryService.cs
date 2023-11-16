using PDI_MongoDB.Domain.Entities;
using PDI_MongoDB.Infra.Repositories;

namespace PDI_MongoDB.Services.Services
{
    public class UserStoryService : IUserStoryService
    {
        private readonly IUserStoryRepository _repository;
        public UserStoryService(IUserStoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserStory> AddAsync(UserStory userStory)
        {
            try
            {
                var model = new UserStory()
                {
                    Id = Guid.NewGuid(),
                    Title = userStory.Title,
                    Description = userStory.Description,
                    Status = userStory.Status,
                    IsEnabled = userStory.IsEnabled,
                };

                await _repository.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserStory> GetByIdAsync(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task<IEnumerable<UserStory>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserStory> UpdateAsync(UserStory userStory)
        {
            try
            {
                await _repository.UpdateAsync(userStory);
                return userStory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
