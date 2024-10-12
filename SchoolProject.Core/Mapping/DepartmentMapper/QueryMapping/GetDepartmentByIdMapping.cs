using SchoolProject.Core.Features.Departments.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.DepartmentMapper
{

    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.InsName))
                //.ForMember(dest => dest.studentResponses, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.subjectResponses, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.instructorResponses, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmentSubject, SubjectResponse>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.SubjectName));


            //CreateMap<Student, StudentResponse>()
            //       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
            //        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Instructor, InstructorResponse>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.InsName));



        }

    }
}
