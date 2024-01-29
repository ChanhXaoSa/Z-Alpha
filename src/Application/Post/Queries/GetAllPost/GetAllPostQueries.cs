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

namespace ZAlpha.Application.Post.Queries.GetAllPost;
public class GetAllPostQueries : IRequest<List<Domain.Entities.Post>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllPostQueriesHandler : IRequestHandler<GetAllPostQueries, List<Domain.Entities.Post>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPostQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Domain.Entities.Post>> Handle(GetAllPostQueries request, CancellationToken cancellationToken)
    {
        var listPost = _context.Get<Domain.Entities.Post>()
            .Where(x => x.IsDeleted == false)
            .Include(o => o.PostTags)
            .ThenInclude(o => o.Tag)
            .Include(o => o.InteractWithPosts)//.Where(i=>i.InteractWithPosts.InteractPostStatus == InteractPostStatus.Create)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.WishListPosts)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.Comments)
            .OrderByDescending(o => o.Created)
            .AsNoTracking().ToList();

        return listPost;
    }
}
