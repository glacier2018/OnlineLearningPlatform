using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos;
using Application.Dtos.PostDtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public class GetAllPosts
    {
        public class Query : IRequest<Response<List<ListPostDto>>> { }

        public class Handler : IRequestHandler<Query, Response<List<ListPostDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<List<ListPostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = await _context.Posts
                    .Where(x => x.IsActive)
                    .ProjectTo<ListPostDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                return posts != null
                    ? Response<List<ListPostDto>>.Succeed(posts)
                    : null;
            }
        }
    }
}