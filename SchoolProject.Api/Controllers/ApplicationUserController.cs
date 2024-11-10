using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Model;
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
        [HttpGet(UserRoute.Paginated)]
        public async Task<IActionResult> GetStudentPaginated([FromQuery] GetUserPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(UserRoute.GetById)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(UserRoute.Edit)]
        public async Task<IActionResult> EditAsync(EditUserCommand editUser)
        {
            var response = await Mediator.Send(editUser);
            return NewResult(response);
        }

        [HttpDelete(UserRoute.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }
    }

}
