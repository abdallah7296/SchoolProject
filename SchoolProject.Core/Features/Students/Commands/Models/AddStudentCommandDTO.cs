using MediatR;
using SchoolProject.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentCommandDTO : IRequest<Response<string>>
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Phone]
        public string? phone { get; set; }
        [Required]
        public int DepartId { get; set; }
    }
}
