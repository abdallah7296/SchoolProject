using SchoolProject.Data.Entities;

namespace SchoolProject.Services.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
    }
}
