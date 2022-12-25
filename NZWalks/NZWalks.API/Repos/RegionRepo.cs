using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public class RegionRepo : IRegionRepository
    {

        private readonly NZWalksDbContext nZWalksDbContext;
        public RegionRepo(NZWalksDbContext nZWalksDbContext) {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync() {
            return await nZWalksDbContext.Regions.ToListAsync();    
        }
    }
}
