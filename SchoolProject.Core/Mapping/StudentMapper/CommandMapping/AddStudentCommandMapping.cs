using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommandDTO, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartId));
        }

    }
}
