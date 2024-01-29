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

namespace ZAlpha.Application.Pack.Queries.GetPack;
public class GetAllPackQueries : IRequest<List<Domain.Entities.Pack>>
{
}

public class GetAllPackQueriesHandler : IRequestHandler<GetAllPackQueries, List<Domain.Entities.Pack>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPackQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Domain.Entities.Pack>> Handle(GetAllPackQueries request, CancellationToken cancellationToken)
    {
        var listPack = _context.Get<Domain.Entities.Pack>()
            .Where(x => x.IsDeleted == false).AsNoTracking().ToList();

        //var map = _mapper.ProjectTo<PackModel>(listPack);

        //var page = await PackModel
        //    .CreateAsync(map, request.Page, request.Size);

        return listPack;
    }
}
