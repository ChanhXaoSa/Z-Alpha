using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.Post.Queries.GetAllPost;

namespace ZAlpha.Application.Post.Queries.GetPostBySearch;
public class GetPostBySearchQueries : IRequest<PaginatedList<PostModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string keySearch { get; set; }
}

public class GetPostBySearchQueriesHandler : IRequestHandler<GetPostBySearchQueries, PaginatedList<PostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPostBySearchQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PostModel>> Handle(GetPostBySearchQueries request, CancellationToken cancellationToken)
    {
        var listPost = _context.Get<Domain.Entities.Post>()
            .Where(x => x.IsDeleted == false &&
            x.PostTitle.Contains(request.keySearch.Trim())||
            x.PostBody.Contains(request.keySearch.Trim()))
            .Include(o => o.PostTags)
            .ThenInclude(o => o.Tag)
            .Include(o => o.InteractWithPosts)//.Where(i=>i.InteractWithPosts.InteractPostStatus == InteractPostStatus.Create)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.WishListPosts)
            .ThenInclude(o => o.UserAccount)
            .AsNoTracking();

        var map = _mapper.ProjectTo<PostModel>(listPost);

        var page = await PaginatedList<PostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}