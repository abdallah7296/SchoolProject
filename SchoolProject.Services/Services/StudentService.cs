using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Services.Services
{
    public class StudentService : IStudentService

    {

        #region fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Hndel Functions
        public async Task<List<Student>> GetStudentsAsync()
               => await _studentRepository.GetStudentsAsync();

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableAsTracking().Include(d => d.Department)
                                           .Where(x => x.StudID.Equals(id))
                                           .FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            var studentResult = _studentRepository.GetTableNoTracking().Where(s => s.Name == student.Name).FirstOrDefault();
            if (studentResult != null) return "Exist";
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var studentResult = await _studentRepository.GetTableNoTracking().Where(s => s.Name.Equals(name) & !s.StudID.Equals(id)).FirstOrDefaultAsync();
            if (studentResult != null) return true;
            return false;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "deleted";
            }
            catch
            {
                await trans.RollbackAsync();
                return "field";
            }

        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
            return queryable;
        }

        public IQueryable<Student> GetStudentsPaginatedFilterQueryable(StudentOrderEnum studentOrderEnum, string search)
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
            if (search != null)
            {
                queryable = queryable.Where(s => s.Name.Contains(search) || s.StudID.ToString().Contains(search) || s.Address.Contains(search));
            }
            switch (studentOrderEnum)
            {
                case StudentOrderEnum.StudID:
                    queryable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderEnum.Address:
                    queryable.OrderBy(x => x.Address);
                    break;
                case StudentOrderEnum.Name:
                    queryable.OrderBy(x => x.Name);
                    break;
                case StudentOrderEnum.DepartName:
                    queryable.OrderBy(x => x.Department.DName);
                    break;
            }
            return queryable;
        }

        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int DId)
        {
            var queryable = _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(DId)).AsQueryable();
            return queryable;
        }

        #endregion


    }
}
