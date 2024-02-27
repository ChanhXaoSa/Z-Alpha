using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ZAlpha.Application.Post.Queries.GetAllPost;

public class GetAllPostInMonthQueries : IRequest<List<Domain.Entities.Post>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllPostInMonthQueriesHandler : IRequestHandler<GetAllPostInMonthQueries, List<Domain.Entities.Post>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPostInMonthQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Domain.Entities.Post>> Handle(GetAllPostInMonthQueries request, CancellationToken cancellationToken)
    {
        DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
        var listPost = _context.Get<Domain.Entities.Post>()
            .Where(x => x.IsDeleted == false && x.Created>= oneMonthAgo)
            .Include(o => o.PostTags)
            .ThenInclude(o => o.Tag)
            .Include(o => o.InteractWithPosts)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.WishListPosts)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.Comments)
            .OrderByDescending(o => o.Created)
            .AsNoTracking().ToList();

        return listPost;
    }
}
