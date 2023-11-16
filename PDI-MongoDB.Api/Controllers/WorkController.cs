using Microsoft.AspNetCore.Mvc;
using PDI_MongoDB.Domain.Entities;
using PDI_MongoDB.Services.Services;

namespace PDI_MongoDB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;
        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _workService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _workService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Work work)
        {
            var result = await _workService.AddAsync(work);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Work work)
        {
            return Ok(await _workService.UpdateAsync(work));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _workService.DeleteAsync(id);
            return NoContent();
        }
    }
}
