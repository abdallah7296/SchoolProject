using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Services.Services
{
    public class DepartmentService : IDepartmentService
    {

        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion 
        #region Constructor  
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region handle Function
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var result = await _departmentRepository.GetTableNoTracking().Where(x => x.DID == id)
                                                                   .Include(ins => ins.Instructors)
                                                                   .Include(ds => ds.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                                                   .Include(s => s.Students)
                                                                   .Include(m => m.Instructor)
                                                                   .FirstOrDefaultAsync();
            return result;
        }

        #endregion




    }
}
