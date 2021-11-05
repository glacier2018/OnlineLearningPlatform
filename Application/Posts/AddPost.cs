using System.Linq;
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
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class AddPost
    {
        public class Command : IRequest<Response<Unit>>
        {
            public AddPostDto AddPostDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.AddPostDto).SetValidator(new PostDtoValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _userManager = userManager;
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                //needs to get current logged in user from UserAccessor
                //needs to validate tagId arrays against context.
                //needs to validate PostCategoryId against context. 
                // var user = await _userManager.FindByEmailAsync(_userAccessor.GetUserEmail());   //FindByEmailAsync will possible cause an exception which is not good!
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUserEmail());
                if (user == null)
                    return Response<Unit>.Fail("can't find user", "400");

                var postCategory = await _context.PostCategories.FindAsync(request.AddPostDto.PostCategoryId);
                if (postCategory == null)
                    return Response<Unit>.Fail("Invalid Post Category Id, please try again", "400");

                var post = _mapper.Map<Post>(request.AddPostDto);
                var tagPosts = new List<TagPost>();
                foreach (var tagId in request.AddPostDto.TagIds)
                {
                    var tag = await _context.Tags.FindAsync(tagId);
                    tagPosts.Add(new TagPost
                    {
                        Post = post,
                        Tag = tag,
                        PostType = postCategory.Id
                    });
                }
                post.TagPosts = tagPosts;
                post.ApplicationUser = user;
                post.ApplicationUserId = user.Id;
                post.PostCategory = postCategory;
                post.IsActive = true;
                post.CreatedAt = DateTime.Now;
                post.UpdatedAt = DateTime.Now;
                _context.Posts.Add(post);
                var result = await _context.SaveChangesAsync() > 0;
                return result
                    ? Response<Unit>.Succeed(Unit.Value)
                    : Response<Unit>.Fail("Problem Saving new post", "500");

            }
        }
    }
}