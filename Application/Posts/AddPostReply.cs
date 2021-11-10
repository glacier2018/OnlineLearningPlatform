using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Application.Dtos.PostReplyDtos;
using AutoMapper;
using Persistence;
using Application.Core;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class AddPostReply
    {
        public class Command : IRequest<Response<Unit>>
        {
            public AddPostReplyDto AddPostReplyDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                // RuleFor(x => x.Unit).SetValidator(new UnitValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<ApplicationUser> _userManager;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor, UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;

            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(_userAccessor.GetUserEmail());
                var postReply = new PostReply { IsActive = true };
                _mapper.Map(request.AddPostReplyDto, postReply);
                var post = await _context.Posts
                    .Include(x => x.PostReplies)
                    .FirstOrDefaultAsync(x => x.Id == request.AddPostReplyDto.PostId);
                if (post == null) return null;
                if (!string.IsNullOrEmpty(request.AddPostReplyDto.TargetPostReplyId.ToString()))
                {
                    var targetPostReply = await _context.PostReplies
                        .FirstOrDefaultAsync(x => x.Id == request.AddPostReplyDto.TargetPostReplyId && x.IsActive);
                    if (targetPostReply == null) return Response<Unit>.Fail("can't find your reply", "403");
                    postReply.TargetPostReply = targetPostReply;
                }

                postReply.ApplicationUser = user;
                postReply.Post = post;
                _context.PostReplies.Add(postReply);
                var result = await _context.SaveChangesAsync() > 0;
                return result
                    ? Response<Unit>.Succeed(Unit.Value)
                    : Response<Unit>.Fail("Problem saving your reply", "500");

                //next needs to find the targetPostReply,
                //does it need ApplicationUserId,PostId and 


            }
        }
    }
}