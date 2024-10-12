﻿using AutoMapper;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();

        }
    }
}
