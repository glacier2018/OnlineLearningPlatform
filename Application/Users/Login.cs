using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.Users
{
    public class Login
    {
        public class Query : IRequest<UserDto>
        {
            public LoginDto loginDto { get; set; }
        }
        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x=> x.loginDto).SetValidator(new LoginValidator());
            }
        }
        public class Handler : IRequestHandler<Query, UserDto>
        {
            public Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                //validate and get user logged in logic goes here
                throw new NotImplementedException();
            }
        }
    }
}