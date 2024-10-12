using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System.Reflection;

namespace SchoolProject.infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmentSubject> departmetSubjects { get; set; }
        public DbSet<Ins_Subject> ins_Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
