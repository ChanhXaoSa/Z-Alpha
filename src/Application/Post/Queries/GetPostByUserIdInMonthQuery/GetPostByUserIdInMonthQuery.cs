using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.Post.Queries.GetAllPost;

namespace ZAlpha.Application.Post.Queries.GetPostByUserIdInMonthQuery;


public class GetPostByUserIdInMonthQuery : IRequest<PaginatedList<PostModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string UserId { get; set; }
}

public class GetPostByUserIdInMonthQueryHandler : IRequestHandler<GetPostByUserIdInMonthQuery, PaginatedList<PostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPostByUserIdInMonthQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PostModel>> Handle(GetPostByUserIdInMonthQuery request, CancellationToken cancellationToken)
    {
        DateTime thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
        var listPost = _context.Get<Domain.Entities.Post>()
            .Where(x => x.IsDeleted == false && x.Created >= thirtyDaysAgo)
            .Include(o => o.InteractWithPosts)
            .ThenInclude(o => o.UserAccount)
            .Where(o => o.InteractWithPosts.Any(i => i.InteractPostStatus == Domain.Enums.InteractPostStatus.Create 
                    && i.UserAccount.Id.Equals(request.UserId))
            )
            .AsNoTracking();

        var map = _mapper.ProjectTo<PostModel>(listPost);

        var page = await PaginatedList<PostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
