using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
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
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.TagIds, opt => opt.MapFrom(x => x.TagPosts.Select(a => a.TagId)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.TagPosts));
            CreateMap<TagPost, TagPostDto>()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(x => x.Tag.TagName));
        }
    }
}