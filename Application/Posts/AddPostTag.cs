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
using System.Linq;

namespace Application.Users
{
    public class AddPostTag
    {
        public class Command : IRequest<Response<Unit>>
        {
            public int PostId { get; set; }
            public int TagId { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                // RuleFor(x => x.example).SetValidator(new exampleValidator());
            }
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
                // var duplicated = await _context.Posts
                //     .Include(x => x.TagPosts)
                //     .ThenInclude(x => x.Tag)
                //     .Where(x => x.Id == request.PostId && x.TagPosts.)
                //     .ToListAsync();
                // var duplicated = await _context.TagPosts
                //         .AnyAsync(x => x.PostId == request.PostId && x.TagId == request.TagId);
                // if (duplicated) return null;
                var tag = await _context.Tags.FindAsync(request.TagId);
                var post = await _context.Posts.FindAsync(request.PostId);
                if (post == null || tag == null) return null;
                var postTag = await _context.TagPosts
                    .Include(x => x.Post)
                    .Include(x => x.Tag)
                    .FirstOrDefaultAsync(x => x.PostId == request.PostId && x.TagId == request.TagId);


                if (postTag == null)
                {
                    postTag = new TagPost
                    {
                        PostType = post.PostCategoryId ?? default(int), //converting int? to int
                        Post = post,
                        // PostId = post.Id,
                        Tag = tag,
                        // TagId = tag.Id
                    };
                    _context.TagPosts.Add(postTag);
                    await _context.SaveChangesAsync();
                    return Response<Unit>.Succeed(Unit.Value);
                };
                return Response<Unit>.Fail("Tag already exists for this post", "403");

            }
        }
    }
}