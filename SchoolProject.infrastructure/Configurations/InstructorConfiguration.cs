using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(x => x.supervisor)
                 .WithMany(x => x.instructors)
                 .HasForeignKey(x => x.SupervisorId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
