using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Comment.Queries.GetComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
namespace ZAlpha.Application.Tag.Queries.GetTag;

public class GetAllTagQueries : IRequest<PaginatedList<TagModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllTagQueriesHandler : IRequestHandler<GetAllTagQueries, PaginatedList<TagModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTagQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TagModel>> Handle(GetAllTagQueries request, CancellationToken cancellationToken)
    {
        var tags = _context.Get<Domain.Entities.Tag>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<TagModel>(tags);

        var page = await PaginatedList<TagModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
