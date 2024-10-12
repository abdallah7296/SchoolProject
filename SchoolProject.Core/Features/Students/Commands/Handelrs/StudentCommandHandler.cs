using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handelrs
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommandDTO, Response<string>>,
                                                          IRequestHandler<EditStudentCommandDTO, Response<string>>,
                                                          IRequestHandler<DeleteStudentCommandDTO, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer,
                                     IDepartmentService departmentService
                                   )
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
        }
        #endregion

        #region Hndel Function
        public async Task<Response<string>> Handle(AddStudentCommandDTO request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var departmentId = await _departmentService.GetDepartmentByIdAsync(request.DepartId);
            if (departmentId == null) return NotFound<string>("The Department Id Not Found");
            var result = await _studentService.AddAsync(studentMapper);
            if (result == "Exist") return UnprocessableEntity<string>("The Name Is Exist");
            else if (result == "Success") return Created<string>("Add success");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommandDTO request, CancellationToken cancellationToken)
        {
            // check Id found or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return Not Found
            if (student == null) return NotFound<string>("Not Found");
            // Mapping  Between Request And Student
            var studentMapper = _mapper.Map(request, student);
            //Call services Edit
            var result = await _studentService.EditAsync(studentMapper);
            //return Response
            if (result == "Success") return Created<string>($"Edit successfully {studentMapper.StudID}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommandDTO request, CancellationToken cancellationToken)
        {
            // check Id found or not
            var student = await _studentService.GetStudentByIdAsync(request.id);
            //return Not Found
            if (student == null) return NotFound<string>("student is not Found");
            //Call services make Delete
            var result = await _studentService.DeleteAsync(student);
            //return Response
            if (result == "deleted") return Deleted<string>();
            else return BadRequest<string>();

        }
        #endregion
    }
}
