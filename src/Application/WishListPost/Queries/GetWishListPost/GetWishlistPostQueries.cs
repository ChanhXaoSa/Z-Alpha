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

using ZAlpha.Application.Common.Exceptions;

namespace ZAlpha.Application.WishListPost.Queries.GetWishListPost;
public class GetWishlistPostQueries : IRequest<PaginatedList<WishListPostModel>>
{
    public string UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}
public class GetWishlistPostQueriesHandler : IRequestHandler<GetWishlistPostQueries, PaginatedList<WishListPostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWishlistPostQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<WishListPostModel>> Handle(GetWishlistPostQueries request, CancellationToken cancellationToken)
    {
        var listPost = _context.Get<Domain.Entities.WishListPost>()
        .Where(x => x.IsDeleted == false
           && x.UserAccountId.Equals(request.UserId))
        .Include(x => x.Post)
        .ThenInclude(o => o.PostTags)
        .ThenInclude(o => o.Tag)
        .Include(x => x.UserAccount)
        .AsNoTracking();

        if (listPost == null)
        {
            throw new NotFoundException(nameof(WishListPost), request.UserId);
        }

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.ProjectTo<WishListPostModel>(listPost);

        var page = await PaginatedList<WishListPostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}