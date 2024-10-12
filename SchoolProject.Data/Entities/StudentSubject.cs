﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StudSubID { get; set; }
        public int? StudID { get; set; }
        public int? SubID { get; set; }
        public decimal? Grade { get; set; } = default(decimal?);

        [ForeignKey("StudID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        public virtual Subjects? Subject { get; set; }

    }
}
