using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class GetOneUser
    {
        public class Query : IRequest<Response<AllUsersDto>>
        {
            public int Id { get; set; }
        }
        public class Hanlder : IRequestHandler<Query, Response<AllUsersDto>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;
            public Hanlder(UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<Response<AllUsersDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (user == null) return null;

                return Response<AllUsersDto>.Succeed(_mapper.Map<AllUsersDto>(user));

            }
        }
    }
}