using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repos
{
    public class StaticUserRepository : IUserRepository
    {

        private List<User> users = new List<User>()
        {
            //new User()
            //{
            //    Id = Guid.NewGuid(),
            //    Firstname = "Read Only",
            //    Lastname = "User",
            //    Email = "readonly@user.com",
            //    Username= "readonly@user.com",
            //    Password = "Readonly@user",
            //    Roles = new List<string> { "reader"}
            //},

            //new User()
            //{
            //    Id = Guid.NewGuid(),
            //    Firstname = "Read Write",
            //    Lastname = "User",
            //    Email = "readwrite@user.com",
            //    Username = "readwrite@user.com",
            //    Password = "Readwrite@user",
            //    Roles = new List<string> { "reader", "writer"}
            //}
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
             var user = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);

            return user; 
        }
    }
}
