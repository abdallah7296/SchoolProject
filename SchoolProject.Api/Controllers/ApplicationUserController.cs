using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using static SchoolProject.Data.AppMetaData.Router;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(UserRoute.Create)]
        public async Task<IActionResult> AddAsync([FromBody] AddUserCommand userCommand)
        {
            var response = await Mediator.Send(userCommand);
            return NewResult(response);
        }
    }

}
