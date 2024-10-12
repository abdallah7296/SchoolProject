using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Features.Students.Commands.Validator
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommandDTO>
    {
        #region Fildes
        #endregion
        #region Constructor
        public AddStudentValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull()
                .MaximumLength(50).MinimumLength(5).WithMessage("The Name Must Max 50 And Minimum 5");

            RuleFor(x => x.Address).NotEmpty()
                .NotNull().WithMessage("{PropertyValue} Must Be Not Null")
                .MaximumLength(50).MinimumLength(5).WithMessage("The Address Must Max 50 And Minimum 5");

            RuleFor(x => x.phone).NotEmpty()
                .NotNull();

        }
        public void ApplyCustomValidationRules()
        {

        }

        #endregion


    }
}
