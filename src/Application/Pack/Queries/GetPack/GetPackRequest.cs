using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZAlpha.Application.AnswersForEntranceTest.Queries.GetAnswersForEntranceTest;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.Pack.Queries.GetPack;

public class GetPackRequest : IRequest<PaginatedList<PackModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetPackRequestHandler : IRequestHandler<GetPackRequest, PaginatedList<PackModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPackRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PackModel>> Handle(GetPackRequest request, CancellationToken cancellationToken)
    {
        var listPack = _context.Get<Domain.Entities.Pack>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<PackModel>(listPack);

        var page = await PaginatedList<PackModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}



