﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.StudID });

            builder.HasOne(x => x.Student)
                .WithMany(x => x.studentSubjects)
                .HasForeignKey(x => x.StudID);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.StudentsSubjects)
                .HasForeignKey(x => x.SubID);
        }
    }
}
