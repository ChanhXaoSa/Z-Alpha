using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.AnswersForEntranceTest.Queries.GetAnswersForEntranceTest;
public class GetAnswersForEntranceTestRequest : IRequest<PaginatedList<AnswersForEntranceTestModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAnswersForEntranceTestRequestHandler : IRequestHandler<GetAnswersForEntranceTestRequest, PaginatedList<AnswersForEntranceTestModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAnswersForEntranceTestRequestHandler(IApplicationDbContext context, IMapper mapper) 
    {
        _context = context; 
        _mapper = mapper;
    }

    public async Task<PaginatedList<AnswersForEntranceTestModel>> Handle(GetAnswersForEntranceTestRequest request, CancellationToken cancellationToken)
    {
        var listAnswersForEntranceTest = _context.Get<Domain.Entities.AnswersForEntranceTest>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<AnswersForEntranceTestModel>(listAnswersForEntranceTest);

        var page = await PaginatedList<AnswersForEntranceTestModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}