using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DID);
            builder.Property(x => x.DName).HasMaxLength(500);

            builder.HasOne(x => x.Instructor)
                   .WithOne(x => x.departmentManager)
                   .HasForeignKey<Department>(x => x.InsManager)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Students)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
