using AutoMapper;
using MediatR;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        #region Fields
        #endregion
        #region Constructor
        public DepartmentQueryHandler(IDepartmentService departmentService,
                                       IMapper mapper,
                                       IStudentService studentService)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _studentService = studentService;
        }
        #endregion

        #region Handle Function

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // Services GetById include st dep ins
            var response = await _departmentService.GetDepartmentByIdAsync(request.Id);

            // check is no Exist
            if (response == null) return NotFound<GetDepartmentByIdResponse>("NOt found Department");
            //mapping
            var mapping = _mapper.Map<GetDepartmentByIdResponse>(response);
            //pagination   
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Name);
            var StudentQueryable = _studentService.GetStudentsByDepartmentIdQueryable(request.Id);
            var paginatedList = await StudentQueryable.Select(expression).ToPaginationListAsync(request.PageNumber, request.pageSize);
            mapping.studentResponses = paginatedList;
            //return Response
            return Success(mapping);
        }
        #endregion
    }
}
