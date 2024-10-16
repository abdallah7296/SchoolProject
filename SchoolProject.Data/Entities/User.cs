using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities
{
    public class User : IdentityUser<int>
    {
<<<<<<< HEAD
        public string FullName { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
=======
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
>>>>>>> 5b38d910be889b9b6a0565f3d81c8bc60614692d

    }
}
