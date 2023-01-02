using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
