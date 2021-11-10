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
    public class DeletePostTag
    {
        public class Command : IRequest<Response<Unit>>
        {
            public int TagId { get; set; }
            public int PostId { get; set; }
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
                var postTag = await _context.TagPosts.FirstOrDefaultAsync(x => x.TagId == request.TagId && x.PostId == request.PostId);
                if (postTag == null) return null;
                _context.TagPosts.Remove(postTag);
                var result = await _context.SaveChangesAsync() > 0;
                return result
                    ? Response<Unit>.Succeed(Unit.Value)
                    : Response<Unit>.Fail("Problem delete the tag", "500");
            }
        }
    }
}