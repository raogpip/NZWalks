using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
