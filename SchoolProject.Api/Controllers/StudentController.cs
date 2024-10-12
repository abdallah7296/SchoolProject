using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using static SchoolProject.Data.AppMetaData.Router;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {


        [HttpGet(StudentRoute.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentQuery());
            return Ok(response);
        }
        [HttpGet(StudentRoute.Paginated)]
        public async Task<IActionResult> GetStudentPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(StudentRoute.GetById)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(StudentRoute.Create)]
        public async Task<IActionResult> AddAsync(AddStudentCommandDTO studentCommandDTO)
        {
            var response = await Mediator.Send(studentCommandDTO);
            return NewResult(response);
        }

        [HttpPost(StudentRoute.Edit)]
        public async Task<IActionResult> EditAsync(EditStudentCommandDTO editStudentCommandDTO)
        {
            var response = await Mediator.Send(editStudentCommandDTO);
            return NewResult(response);
        }

        [HttpDelete(StudentRoute.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommandDTO(id));
            return NewResult(response);
        }
    }
}
