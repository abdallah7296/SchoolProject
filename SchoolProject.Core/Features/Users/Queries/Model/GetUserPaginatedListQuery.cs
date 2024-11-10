using MediatR;
using SchoolProject.Core.Features.Users.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.Model
{
    public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int pageSize { get; set; }

    }
}
