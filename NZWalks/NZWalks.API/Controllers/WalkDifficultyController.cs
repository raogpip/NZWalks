using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repos;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper )
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWDs()
        {
            var walkDiff = await walkDifficultyRepository.GetAllAsync();
            var walkDiffDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDiff);
            return Ok(walkDiffDTO); 
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var walkDiff = await walkDifficultyRepository.GetAsync(id);

            if (walkDiff == null)
                return NotFound();

            var walkDiffDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDiff);
            return Ok(walkDiffDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(
            Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var walkDiff = new Models.Domain.WalkDifficulty()
            {
                Code = addWalkDifficultyRequest.Code
            };
            walkDiff = await walkDifficultyRepository.AddAsync(walkDiff);

            var walkDiffDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDiff);
            return CreatedAtAction(nameof(GetWalkDifficultyAsync), 
                new { id = walkDiffDTO.Id }, walkDiffDTO);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.DeleteAsync(id);
            
            if(walkDifficulty== null) return NotFound();

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO); 
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            var walkDifficulty = new Models.Domain.WalkDifficulty()
            {
                Code = updateWalkDifficultyRequest.Code
            };

            walkDifficulty = await walkDifficultyRepository.UpdateAsync(id, walkDifficulty);

            if(walkDifficulty== null) return NotFound();

            var walkDifficutyDTO = new Models.DTO.WalkDifficulty()
            {
                Id = walkDifficulty.Id,
                Code = updateWalkDifficultyRequest.Code
            };

            return Ok(walkDifficutyDTO);
        }

    }
}
