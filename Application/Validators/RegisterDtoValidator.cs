using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password required")
                .MinimumLength(4).WithMessage("Password min length is 4 digits")
                .Matches("[A-Z]").WithMessage("Password must have upper case letter ")
                .Matches("[a-z]").WithMessage("Password must have lower case letter")
                .Matches("[0-9]").WithMessage("Password must have number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must have special character");
        }
    }
}