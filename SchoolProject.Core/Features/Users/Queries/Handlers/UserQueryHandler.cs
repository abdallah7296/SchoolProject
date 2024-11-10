using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Users.Queries.Model;
using SchoolProject.Core.Features.Users.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Users.Queries.Handelrs
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserPaginatedListResponse>>
                                                   , IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #region Fildes
        #endregion

        #region Constructor
        public UserQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region Hndel Function
        public Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //  Expression<Func<User,GetUserPaginatedListResponse>> expression = e => new GetUserPaginatedListResponse(e.FullName,e.UserName,e.Email,e.Country,e.Address);
            var UserList = _userManager.Users.AsQueryable();
            var paginatedList = _mapper.ProjectTo<GetUserPaginatedListResponse>(UserList).ToPaginationListAsync(request.pageSize, request.PageNumber);
            return paginatedList;

        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) NotFound<GetUserByIdResponse>();
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
        #endregion

    }
}
