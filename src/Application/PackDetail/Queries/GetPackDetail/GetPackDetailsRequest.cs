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

namespace CleanArchitecture.Application.PackDetail.Queries.GetPackDetail;

public class GetPackDetailsRequest : IRequest<PaginatedList<PackDetailsModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetPackDetailsRequestHandler : IRequestHandler<GetPackDetailsRequest, PaginatedList<PackDetailsModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPackDetailsRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PackDetailsModel>> Handle(GetPackDetailsRequest request, CancellationToken cancellationToken)
    {
        var listPackDetails = _context.Get<Domain.Entities.PackDetail>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<PackDetailsModel>(listPackDetails);

        var page = await PaginatedList<PackDetailsModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
