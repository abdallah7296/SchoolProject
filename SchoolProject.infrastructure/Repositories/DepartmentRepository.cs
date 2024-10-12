using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.Context;
using SchoolProject.infrastructure.infrastructure;

namespace SchoolProject.infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments;

        #endregion
        #region Constructor
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            departments = dbContext.Set<Department>();
        }

        #endregion
        #region Hndle Function

        #endregion
    }

}
