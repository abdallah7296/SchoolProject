using MediatR;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Students.Results;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentQuery : IRequest<Response<List<GetStudentDTO>>>
    {
    }
}
