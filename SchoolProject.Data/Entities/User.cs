using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

    }
}
