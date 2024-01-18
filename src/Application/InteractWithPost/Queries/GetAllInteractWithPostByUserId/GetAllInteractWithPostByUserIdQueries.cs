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
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPost;
using ZAlpha.Domain.Entities;

namespace ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;
public class GetAllInteractWithPostByUserIdQueries : IRequest<PaginatedList<InteractWithPostModel>>
{
    public Guid UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllInteractWithPostByUserIdQueriesHandler : IRequestHandler<GetAllInteractWithPostByUserIdQueries, PaginatedList<InteractWithPostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetAllInteractWithPostByUserIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<InteractWithPostModel>> Handle(GetAllInteractWithPostByUserIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var listPost = _context.Get<InteractWithPosts>()
            .Where(x => x.IsDeleted == false
            && x.UserAccountId.Equals(request.UserId)
            && x.InteractPostStatus == Domain.Enums.InteractPostStatus.Create)
            .Include(x => x.Post)
            .AsNoTracking();

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.ProjectTo<InteractWithPostModel>(listPost);

        var page = await PaginatedList<InteractWithPostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}