using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.Pack.Queries.GetPack;
using ZAlpha.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.Post.Queries.GetAllPost;
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
            .Where(x => x.IsDeleted == false)
            .Include(o => o.PostTags)
            .ThenInclude(o => o.Tag)
            .Include(o => o.InteractWithPosts)//.Where(i=>i.InteractWithPosts.InteractPostStatus == InteractPostStatus.Create)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.WishListPosts)
            .ThenInclude(o => o.UserAccount)
            .OrderByDescending(o=>o.Created)
            .AsNoTracking();

        var map = _mapper.ProjectTo<PostModel>(listPost);

        var page = await PaginatedList<PostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
