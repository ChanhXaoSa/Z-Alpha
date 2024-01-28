using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.Post.Queries.GetAllPost;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.Post.Queries.GetPostWishListByUserIdQuery;


public class GetPostWishListByUserIdQuery : IRequest<PaginatedList<PostModel>>
{
    public string UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetPostWishListByUserIdQueryHandler : IRequestHandler<GetPostWishListByUserIdQuery, PaginatedList<PostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPostWishListByUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PostModel>> Handle(GetPostWishListByUserIdQuery request, CancellationToken cancellationToken)
    {
        var listPost = _context.Get<Domain.Entities.Post>()
          .Where(x => x.IsDeleted == false)
           .Include(o => o.WishListPosts)
          .ThenInclude(o => o.UserAccount)
          .Where(o => o.WishListPosts.Any(i => i.UserAccount.Id.Equals(request.UserId) && i.IsDeleted == false))
          .Include(o => o.PostTags)
          .ThenInclude(o => o.Tag)
          .Include(o => o.InteractWithPosts)
          .ThenInclude(o => o.UserAccount)        
          .Include(o => o.Comments)
          .OrderByDescending(o => o.Created)
          .AsNoTracking();

        var map = _mapper.ProjectTo<PostModel>(listPost);

        var page = await PaginatedList<PostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
