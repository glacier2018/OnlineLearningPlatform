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
using Application.Interfaces;
using System.Collections.Generic;

namespace Application.Users
{
    public class UpatePost
    {
        public class Command : IRequest<Response<Unit>>
        {
            public UpdatePostDto UpdatePostDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                // RuleFor(x => x.ListPostDto).SetValidator(new ListPostDtoValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts
                        .Include(x => x.TagPosts)
                        .ThenInclude(a => a.Post)
                        .FirstOrDefaultAsync(x =>
                        x.ApplicationUserId == _userAccessor.GetUserId() &&
                        x.Id == request.UpdatePostDto.PostId && x.IsActive);

                if (post == null)   
                    return null;

                _context.RemoveRange(post.TagPosts);

                post.TagPosts = new List<TagPost>();

                var tagPosts = new List<TagPost>();
                foreach (var tagId in request.UpdatePostDto.TagIds)
                {
                    var tag = await _context.Tags.FindAsync(tagId);
                    tagPosts.Add(new TagPost
                    {
                        Post = post,
                        Tag = tag,
                        PostType = request.UpdatePostDto.PostCategoryId
                    });
                }
                post.TagPosts = tagPosts;
                post = _mapper.Map(request.UpdatePostDto, post);
                var result = await _context.SaveChangesAsync() > 0;
                return result
                    ? Response<Unit>.Succeed(Unit.Value)
                    : Response<Unit>.Fail("Problem Saving new post", "500");
            }
        }
    }
}