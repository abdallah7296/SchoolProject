using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using static SchoolProject.Data.AppMetaData.Router;

namespace SchoolProject.Api.Controllers
{
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(DepartmentRoute.GetById)]
        public async Task<IActionResult> DepartmentById([FromQuery] GetDepartmentByIdQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
