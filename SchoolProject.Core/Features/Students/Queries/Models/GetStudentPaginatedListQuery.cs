using MediatR;
using SchoolProject.Core.Features.Students.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListDTO>>
    {
        public int PageNumber { get; set; }
        public int pageSize { get; set; }
        public StudentOrderEnum OrderBy { get; set; }
        public string? Search { get; set; }

    }
}
