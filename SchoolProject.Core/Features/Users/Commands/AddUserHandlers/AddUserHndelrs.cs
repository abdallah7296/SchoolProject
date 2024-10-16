using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Users.Commands.AddUserHandlers
{
    public class AddUserHandlers : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #region Fildes
        #endregion
        #region Constructor
        public AddUserHandlers(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region Handle Function
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // check Email   is exist or no
            var Email = await _userManager.FindByEmailAsync(request.Email);
            if (Email != null) return BadRequest<string>(" Email Already Exist");
            //Check UserNAme is exist or no
            var UserName = await _userManager.FindByNameAsync(request.UserName);
            if (UserName != null) return BadRequest<string>("User Name Already Exist");
            //Mappin
            var userMapping = _mapper.Map<User>(request);
            // create User
            var CreateResult = await _userManager.CreateAsync(userMapping, request.Password);
            if (!CreateResult.Succeeded) return BadRequest<string>(CreateResult.Errors.FirstOrDefault().Description);
            // Created
            return Created("Added User Successfully ");
        }
        #endregion

    }
}
