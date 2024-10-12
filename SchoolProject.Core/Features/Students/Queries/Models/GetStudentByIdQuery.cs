using MediatR;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Students.Results;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentDTO>>
    {
        public int id { get; set; }
        public GetStudentByIdQuery(int id) 
        {
            this.id = id;
        }
    }
}
