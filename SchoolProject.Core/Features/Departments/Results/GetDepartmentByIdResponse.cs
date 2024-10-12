using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Results
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public PaginatedResult<StudentResponse> studentResponses { get; set; }
        public List<SubjectResponse> subjectResponses { get; set; }
        public List<InstructorResponse> instructorResponses { get; set; }

    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public StudentResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
