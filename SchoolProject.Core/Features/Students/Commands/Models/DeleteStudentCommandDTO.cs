using MediatR;
using SchoolProject.Core.Base;
namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommandDTO : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteStudentCommandDTO(int id)
        {
            this.id = id;
        }
    }
}
