using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.UserMapper
{
    public partial class ApplicationUserProfile
    {
        public void AddUserCommandMapping()
        {
            CreateMap<AddUserCommand, User>();
        }

    }
}
