using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using Application.Dtos;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts
{
    public class GetPostById
    {
        public class Query : IRequest<Response<ListPostDto>>
        { public int Id { get; set; } }

        public class Handler : IRequestHandler<Query, Response<ListPostDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Response<ListPostDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts
                    .Where(x => x.IsActive)
                    .ProjectTo<ListPostDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                return post == null
                    ? null
                    : Response<ListPostDto>.Succeed(post);
            }
        }

    }
}