using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Services.Abstracts;
namespace SchoolProject.Core.Features.Students.Commands.Validator
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommandDTO>
    {

        #region Fildes
        private readonly IStudentService _studentService;
        #endregion
        #region Constructor
        public EditStudentValidator(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _studentService = studentService;
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull()
                .MaximumLength(50).MinimumLength(3).WithMessage("The Name Must Max 50 And Minimum 5");

            //RuleFor(x => x.Address)
            //    .NotNull().WithMessage("{PropertyValue} Must Be Not Null")
            //    .MaximumLength(50).MinimumLength(5).WithMessage("The {propertyName} Must Max 50 And Minimum 5");

            RuleFor(x => x.phone).NotEmpty()
                .NotNull();
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name).MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
                .WithMessage("The name is Exist");
        }

        #endregion
    }
}
