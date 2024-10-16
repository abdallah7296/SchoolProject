using AutoMapper;

namespace SchoolProject.Core.Mapping.UserMapper
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserCommandMapping();
        }
    }
}
