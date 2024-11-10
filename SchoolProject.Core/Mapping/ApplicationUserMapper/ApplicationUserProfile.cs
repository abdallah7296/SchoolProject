using AutoMapper;

namespace SchoolProject.Core.Mapping.ApplicationUserMapper
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserCommandMapping();
            GetPaginationListMapping();
            GetUserByIdMapping();
            EditUserCommandMapping();
        }
    }
}
