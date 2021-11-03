using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class UpdateUser
    {
        public class Command : IRequest<Response<UpdateUserDto>>
        {
            public UpdateUserDto UpdateUserDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UpdateUserDto).SetValidator(new UpdateUserDtoValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<UpdateUserDto>>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            private readonly UserManager<ApplicationUser> _userManager;
            public Handler(UserManager<ApplicationUser> userManager, IUserAccessor userAccessor, DataContext context, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Response<UpdateUserDto>> Handle(Command request, CancellationToken cancellationToken)
            {

                var user = await _userManager.FindByEmailAsync(_userAccessor.GetUserEmail());
                if (user == null) return null;

                _mapper.Map(request.UpdateUserDto, user);

                var result = await _userManager.UpdateAsync(user);

                return result.Succeeded
                    ? Response<UpdateUserDto>.Succeed(request.UpdateUserDto)
                    : Response<UpdateUserDto>.Fail("Problem updating user info", "500");

            }
        }
    }
}