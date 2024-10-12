using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            instructors = new List<Instructor>();
            Ins_Subjects = new List<Ins_Subject>();
        }
        [Key]
        public int InsId { get; set; }
        public string? InsName { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? SupervisorSalary { get; set; }

        public int? DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public Department? department { get; set; }

        [InverseProperty("Instructor")]
        public Department? departmentManager { get; set; }


        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("instructors")]
        public virtual Instructor? supervisor { get; set; }
        [InverseProperty("supervisor")]
        public virtual ICollection<Instructor> instructors { get; set; }

        [InverseProperty("Instructor")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }





    }
}
