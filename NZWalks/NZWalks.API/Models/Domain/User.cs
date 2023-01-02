using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        [NotMapped]
        public List<string> Roles { get; set; }

        // Navigation property
        public List<User_role> UserRoles { get; set; }

    }
}
