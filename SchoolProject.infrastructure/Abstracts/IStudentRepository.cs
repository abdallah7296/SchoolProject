using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.infrastructure;

namespace SchoolProject.infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsAsync();
    }
}
