using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.ApplicationUserMapper
{
    public partial class ApplicationUserProfile
    {
        public void EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, User>();
        }
    }
}
