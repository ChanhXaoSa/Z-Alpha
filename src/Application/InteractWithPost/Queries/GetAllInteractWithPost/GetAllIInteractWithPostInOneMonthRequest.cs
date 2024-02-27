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

namespace ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPost;
public class GetAllIInteractWithPostInOneMonthRequest : IRequest<PaginatedList<InteractWithPostModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllIInteractWithPostInOneMonthRequestHandler : IRequestHandler<GetAllIInteractWithPostInOneMonthRequest, PaginatedList<InteractWithPostModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllIInteractWithPostInOneMonthRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<InteractWithPostModel>> Handle(GetAllIInteractWithPostInOneMonthRequest request, CancellationToken cancellationToken)
    {
        var interactWithPost = _context.Get<Domain.Entities.InteractWithPosts>()
            .Where(x => x.IsDeleted == false && x.Created >= DateTime.Now.AddMonths(-1)).AsNoTracking();

        var map = _mapper.ProjectTo<InteractWithPostModel>(interactWithPost);

        var page = await PaginatedList<InteractWithPostModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
