using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class DeleteUser
    {
        public class Command : IRequest<Response<Unit>>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            public Handler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (user == null) return null;

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return Response<Unit>.Succeed(Unit.Value);

                return Response<Unit>.Fail("Problem Delete using", "500");

            }
        }
    }
}