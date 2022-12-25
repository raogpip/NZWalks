using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
