using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Configurations
{
    public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(ds => new { ds.SubID, ds.DID });

            builder.HasOne(ds => ds.Department)
                   .WithMany(ds => ds.DepartmentSubjects)
                   .HasForeignKey(ds => ds.DID);

            builder.HasOne(ds => ds.Subjects)
                  .WithMany(ds => ds.DepartmentsSubjects)
                  .HasForeignKey(ds => ds.SubID);

        }
    }
}
