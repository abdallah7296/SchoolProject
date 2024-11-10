using SchoolProject.Core.Features.Users.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.ApplicationUserMapper
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }

    }
}
