using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

        Task<WalkDifficulty> GetAsync(Guid id);

        Task<WalkDifficulty> AddAsync(WalkDifficulty entity);

        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> DeleteAsync(Guid id);

        
    }
}
