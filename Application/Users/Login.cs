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

namespace Application.Users
{
    public class Login
    {
        public class Query : IRequest<Response<OneUserDto>>
        {
            public LoginDto LoginDto { get; set; }
        }
        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.LoginDto).SetValidator(new LoginDtoValidator());
            }
        }
        public class Handler : IRequestHandler<Query, Response<OneUserDto>>
        {
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;
            private readonly ITokenService _tokenService;

            public Handler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMapper mapper, ITokenService tokenService)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _mapper = mapper;
                _tokenService = tokenService;
            }

            public async Task<Response<OneUserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.LoginDto.Email);
                if (user == null) return null;

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginDto.Password, false);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<OneUserDto>(user);
                    userToReturn.Token = _tokenService.CreateToken(user);
                    return Response<OneUserDto>.Succeed(userToReturn);
                }
                return Response<OneUserDto>.Fail("wrong email or password, please try again", "401");

            }
        }
    }
}