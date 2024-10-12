using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Configurations
{
    public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(ds => new { ds.SubId, ds.InsId });

            builder.HasOne(x => x.Instructor)
                   .WithMany(x => x.Ins_Subjects)
                   .HasForeignKey(ds => ds.InsId);

            builder.HasOne(ds => ds.Subjects)
                  .WithMany(ds => ds.Ins_Subjects)
                  .HasForeignKey(ds => ds.SubId);

        }
    }
}
