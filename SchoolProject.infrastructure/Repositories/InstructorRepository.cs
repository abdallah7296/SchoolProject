using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Context;
using SchoolProject.infrastructure.infrastructure;

namespace SchoolProject.infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion
        #region Constructor
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }

        #endregion
        #region Hndle Function

        #endregion
    }
}
