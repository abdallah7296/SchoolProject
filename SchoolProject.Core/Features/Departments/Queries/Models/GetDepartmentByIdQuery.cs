using MediatR;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Departments.Results;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int pageSize { get; set; }

    }
}
