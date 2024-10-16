using MediatR;
using SchoolProject.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        // public string phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }



    }
}
