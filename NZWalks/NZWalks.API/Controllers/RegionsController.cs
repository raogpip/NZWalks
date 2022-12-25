using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repos;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionsRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionsRepository, IMapper mapper)
        {
            this.regionsRepository = regionsRepository;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionsRepository.GetAllAsync();

            // return DTO regions
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region => 
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };

            //    regionsDTO.Add(regionDTO);
            //});

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }
        
    }
}
