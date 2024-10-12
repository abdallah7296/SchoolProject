using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Context;
using SchoolProject.infrastructure.infrastructure;

namespace SchoolProject.infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subjects> subjects;

        #endregion
        #region Constructor
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            subjects = dbContext.Set<Subjects>();
        }

        #endregion
        #region Hndle Function

        #endregion
    }
}
