using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.UserDtos;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is Required");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is Required");
        }
    }
}