using System;
using System.Collections.Generic;
using System.Linq;
using Application.Dtos.PostDtos;
using Application.Dtos.PostReplyDtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, AllUsersDto>();
            CreateMap<ApplicationUser, OneUserDto>();
            CreateMap<UpdateUserDto, ApplicationUser>();
            CreateMap<AddPostDto, Post>();
            CreateMap<Post, ListPostDto>()
                .ForMember(dest => dest.TagIds, opt => opt.MapFrom(x => x.TagPosts.Select(a => a.TagId)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.TagPosts))
                .ForMember(dest => dest.PostReplies, opt => opt.MapFrom(x => x.PostReplies.Where(a => a.IsActive)));
            CreateMap<TagPost, TagPostDto>()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(x => x.Tag.TagName));
            CreateMap<UpdatePostDto, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.PostId));
            CreateMap<AddPostReplyDto, PostReply>();
            CreateMap<PostReply, ListPostReplyDto>()
                .ForMember(dest => dest.PostReplyId, opt => opt.MapFrom(x => x.Id));



        }
    }
}
