using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.PostDtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public class GetPostsByUserId
    {
        public class Query : IRequest<Response<List<ListPostDto>>>
        { public int ApplicationUserId { get; set; } }

        public class Handler : IRequestHandler<Query, Response<List<ListPostDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Response<List<ListPostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = await _context.Posts.Where(x => x.ApplicationUserId == request.ApplicationUserId).ToListAsync();
                if (posts == null) return null;
                return Response<List<ListPostDto>>.Succeed(_mapper.Map<List<ListPostDto>>(posts));
            }
        }

    }
}