using MediatR;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Users.Results;

namespace SchoolProject.Core.Features.Users.Queries.Model
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

    }
}
