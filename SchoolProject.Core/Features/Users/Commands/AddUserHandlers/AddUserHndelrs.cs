using MediatR;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.AddUserHandlers
{
    public class AddUserHandlers : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fildes
        #endregion
        #region Constructor\
        public AddUserHandlers()
        {

        }
        #endregion
        #region Handle Function
        public Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
