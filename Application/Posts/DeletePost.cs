using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Application.Dtos;
using AutoMapper;
using Persistence;
using Application.Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class DeletePost
    {
        public class Command : IRequest<Response<Unit>>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FirstOrDefaultAsync(x => x.IsActive && x.Id == request.Id);
                if (post == null)
                    return null;
                post.IsActive = false;
                var result = await _context.SaveChangesAsync() > 0;
                return result
                    ? Response<Unit>.Succeed(Unit.Value)
                    : Response<Unit>.Fail("Problem deleting your post", "500");
            }
        }
    }
}