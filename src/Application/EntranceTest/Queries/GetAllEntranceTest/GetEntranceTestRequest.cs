using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.AnswersForEntranceTest.Queries.GetAnswersForEntranceTest;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.EntranceTest.Queries.GetAllEntranceTest;

public class GetEntranceTestRequest : IRequest<PaginatedList<EntranceTestModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetEntranceTestRequestHandler : IRequestHandler<GetEntranceTestRequest, PaginatedList<EntranceTestModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEntranceTestRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EntranceTestModel>> Handle(GetEntranceTestRequest request, CancellationToken cancellationToken)
    {
        var entranceTests = _context.Get<Domain.Entities.EntranceTest>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<EntranceTestModel>(entranceTests);

        var page = await PaginatedList<EntranceTestModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
