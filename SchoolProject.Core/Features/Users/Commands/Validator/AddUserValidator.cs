using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validator
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        #endregion
        #region Constructor
        public AddUserValidator()
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

            RuleFor(x => x.Password).NotEmpty()
               .NotNull()
               .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
               .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
               .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
               .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
               .Matches(@"[\W]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .NotNull()
                .Equal(x => x.Password).WithMessage("Confirm Password must match the Password.");

            //RuleFor(x => x.phone).NotEmpty()
            //   .NotNull()
            //   .Matches(@"^\+?\d{10,15}$")
            //   .WithMessage("Please enter a valid phone number with a length between 10 and 15 digits.");

        }
        public void ApplyCustomValidationRules()
        {

        }

        #endregion

    }
}
