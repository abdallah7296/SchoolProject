using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validator
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Constructor
        public EditUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Hndle Action
        public void ApplyValidationRules()
        {
            RuleFor(x => x.FullName).NotEmpty()
                .NotNull()
                .MaximumLength(50).MinimumLength(5).WithMessage("The FullName Must Max 50 And Minimum 5");

            RuleFor(x => x.UserName).NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("Username must be at least 5 characters long.")
            .MaximumLength(20).WithMessage("Username must not exceed 20 characters.")
            .Matches(@"^[a-zA-Z0-9_]*$").WithMessage("Username can only contain letters, numbers, and underscores.");

            RuleFor(x => x.Email).NotEmpty()
                .NotNull().WithMessage("{PropertyValue} Must Be Not Null").EmailAddress().WithMessage("Please Enter valid Email");

            RuleFor(x => x.Address).NotEmpty()
            .NotNull()
            .MaximumLength(100).WithMessage("Address must not exceed 100 characters.")
            .MinimumLength(10).WithMessage("Address must be at least 10 characters long.");

            RuleFor(x => x.Country).NotEmpty()
                .NotNull()
                .MaximumLength(50).MinimumLength(5).WithMessage("The Name Country Must Max 50 And Minimum 5");

        }
        public void ApplyCustomValidationRules()
        {

        }

        #endregion

    }
}


