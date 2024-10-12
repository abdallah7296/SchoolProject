using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommandDTO, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartId))
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id));
        }

    }
}
