using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Context;
using SchoolProject.infrastructure.infrastructure;

namespace SchoolProject.infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fieleds
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }
        #endregion
        #region Handels Function

        public async Task<List<Student>> GetStudentsAsync()
            => await _students.Include(d => d.Department).ToListAsync();
        #endregion
    }
}
