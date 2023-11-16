using Microsoft.AspNetCore.Mvc;
using PDI_MongoDB.Domain.Entities;
using PDI_MongoDB.Services.Services;

namespace PDI_MongoDB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryController : ControllerBase
    {
        private readonly IUserStoryService _userStoryService;
        public UserStoryController(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userStoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _userStoryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] UserStory userStory)
        {
            var result = await _userStoryService.AddAsync(userStory);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UserStory userStory)
        {
            return Ok(await _userStoryService.UpdateAsync(userStory));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _userStoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
