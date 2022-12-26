using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public class WalkDifficultyRepo : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepo(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty entity)
        {
            entity.Id = Guid.NewGuid();
            await nZWalksDbContext.WalkDifficulty.AddAsync(entity);
            await nZWalksDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDifficulty = await nZWalksDbContext.WalkDifficulty.FindAsync(id);
            
            if (walkDifficulty == null)
                return null;

            nZWalksDbContext.WalkDifficulty.Remove(walkDifficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return walkDifficulty; 
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDbContext
                .WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return  await nZWalksDbContext
                .WalkDifficulty
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await nZWalksDbContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
                return null;

            existingWalkDifficulty.Code = walkDifficulty.Code;
            await nZWalksDbContext.SaveChangesAsync();
            return existingWalkDifficulty; 
        }
    }
}
