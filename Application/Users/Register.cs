using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using Application.Dtos.UserDtos;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class Register
    {
        public class Command : IRequest<Response<OneUserDto>>
        {
            public RegisterDto RegisterDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RegisterDto).SetValidator(new RegisterDtoValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<OneUserDto>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;
            private readonly ITokenService _tokenService;
            public Handler(UserManager<ApplicationUser> userManager, IMapper mapper, ITokenService tokenService)
            {
                _tokenService = tokenService;
                _mapper = mapper;
                _userManager = userManager;

            }

            public async Task<Response<OneUserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == request.RegisterDto.Email))
                    return Response<OneUserDto>.Fail("Email already token", "400");

                var user = new ApplicationUser
                {
                    Photo = null,
                    Email = request.RegisterDto.Email,
                    UserName = request.RegisterDto.Email,
                    UserType = 1,
                    FirstName = request.RegisterDto.FirstName,
                    LastName = request.RegisterDto.LastName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, request.RegisterDto.Password);

                if (result.Succeeded)
                {
                    var userDto = _mapper.Map<OneUserDto>(user);
                    userDto.Token = _tokenService.CreateToken(user);
                    return Response<OneUserDto>.Succeed(userDto);
                }

                return Response<OneUserDto>.Fail("Problem registering new user", "500");

            }
        }
    }
}