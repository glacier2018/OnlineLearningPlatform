using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class GetAllUsers
    {
        public class Query : IRequest<Response<List<AllUsersDto>>>
        {

        }
        public class Handler : IRequestHandler<Query, Response<List<AllUsersDto>>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<Response<List<AllUsersDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _userManager.Users.ProjectTo<AllUsersDto>(_mapper.ConfigurationProvider).ToListAsync();
                return Response<List<AllUsersDto>>.Succeed(users);
            }
        }
    }
}