using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Pack.Queries.GetPack;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Post.Queries.GetAllPost;

public class GetPostQueries : IRequest<PaginatedList<PostModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetPostQueriesHandler : IRequestHandler<GetPostQueries, PaginatedList<PostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPostQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PostModel>> Handle(GetPostQueries request, CancellationToken cancellationToken)
    {
        var listPost = _context.Get<Domain.Entities.Post>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<PostModel>(listPost);

        var page = await PaginatedList<PostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
