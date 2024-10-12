using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handelrs
{
    public class StudentQueryHandler : ResponseHandler,
                                                      IRequestHandler<GetStudentQuery, Response<List<GetStudentDTO>>>,
                                                      IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentDTO>>,
                                                      IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListDTO>>
    {
        #region Field
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer _stringLocalizer;
        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentService studentService,
                                    IMapper mapper,
                                    IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Hndle Function
        public async Task<Response<List<GetStudentDTO>>> Handle(GetStudentQuery request,
                                                                CancellationToken cancellationToken)
        {
            var StudentList = await _studentService.GetStudentsAsync();
            var studentListMapper = _mapper.Map<List<GetStudentDTO>>(StudentList);
            var result = Success(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }

        public async Task<Response<GetSingleStudentDTO>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.id);
            if (student == null) return NotFound<GetSingleStudentDTO>(_stringLocalizer[SharedResourcesKey.NotFound]);
            var result = _mapper.Map<GetSingleStudentDTO>(student);
            return Success(result);

        }

        public async Task<PaginatedResult<GetStudentPaginatedListDTO>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListDTO>> expression = e => new GetStudentPaginatedListDTO(e.StudID, e.Name, e.Address, e.Department.DName);
            //var queryable = _studentService.GetStudentsQueryable();
            var FilterQuery = _studentService.GetStudentsPaginatedFilterQueryable(request.OrderBy, request.Search);
            var paginatedList = await FilterQuery.Select(expression).ToPaginationListAsync(request.PageNumber, request.pageSize);
            paginatedList.meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;

        }
        #endregion
    }
}
