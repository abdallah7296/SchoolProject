﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student
    {
        public Student()
        {
            studentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        [StringLength(500)]
        public string? Phone { get; set; }
        public int? DID { get; set; }

        [ForeignKey("DID")]
        public virtual Department? Department { get; set; }

        public ICollection<StudentSubject> studentSubjects { get; set; }
    }
}
