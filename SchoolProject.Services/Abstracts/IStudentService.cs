using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQueryable();
        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int Did);
        public IQueryable<Student> GetStudentsPaginatedFilterQueryable(StudentOrderEnum studentOrderEnum, string search);

        public Task<bool> IsNameExistExcludeSelf(string name, int id);
    }
}
