using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subjects
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmentsSubjects = new HashSet<DepartmentSubject>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectName { get; set; }
        public int Period { get; set; }
        public virtual ICollection<StudentSubject>? StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentSubject>? DepartmentsSubjects { get; set; }
        [InverseProperty("Subjects")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
