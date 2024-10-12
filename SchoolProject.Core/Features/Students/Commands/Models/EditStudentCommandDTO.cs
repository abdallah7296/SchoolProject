using MediatR;
using SchoolProject.Core.Base;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class EditStudentCommandDTO : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; }
        public string? phone { get; set; }
        public int DepartId { get; set; }
    }
}
