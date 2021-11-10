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

namespace Application.Users
{
    public class DeletePostReply
    {
        public class Command : IRequest<Response<Unit>>
        {
            public int PostReplyId { get; set; }
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
                var postReply = await _context.PostReplies.FindAsync(request.PostReplyId);
                if (postReply == null) return null;
                // _context.PostReplies.Remove(postReply);
                postReply.IsActive = false;
                var result = await _context.SaveChangesAsync() > 0 ;
                return result
                    ? Response<Unit>.Succeed(Unit.Value)
                    : Response<Unit>.Fail("problem deleting post reply","500");
            }
        }
    }
}