using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.PostDtos;
using FluentValidation;

namespace Application.Validators
{
    public class PostDtoValidator : AbstractValidator<AddPostDto>
    {
        public PostDtoValidator()
        {

        }
    }
}