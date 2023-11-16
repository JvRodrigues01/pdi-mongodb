using PDI_MongoDB.Domain.Entities;
using PDI_MongoDB.Infra.Repositories;

namespace PDI_MongoDB.Services.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _repository;
        public WorkService(IWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<Work> AddAsync(Work work)
        {
            try
            {
                var model = new Work()
                {
                    Id = Guid.NewGuid(),
                    Name = work.Name,
                    Description = work.Description,
                    IsComplete = work.IsComplete,
                    IsEnabled = work.IsEnabled,
                };

                await _repository.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Work> GetByIdAsync(Guid id)
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

        public async Task<IEnumerable<Work>> GetAllAsync()
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

        public async Task<Work> UpdateAsync(Work work)
        {
            try
            {
                await _repository.UpdateAsync(work);
                return work;
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
