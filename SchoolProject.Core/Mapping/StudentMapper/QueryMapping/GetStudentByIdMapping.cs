using SchoolProject.Core.Features.Students.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentDTO>()
                .ForMember(dest => dest.DepartName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}