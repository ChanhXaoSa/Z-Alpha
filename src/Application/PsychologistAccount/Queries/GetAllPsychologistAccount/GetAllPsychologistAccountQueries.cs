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
using ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;

namespace ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;
public class GetAllPsychologistAccountQueries : IRequest<PaginatedList<PsychologistAccountModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}
public class GetAllPsychologistAccountQueriesHandler : IRequestHandler<GetAllPsychologistAccountQueries, PaginatedList<PsychologistAccountModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPsychologistAccountQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PsychologistAccountModel>> Handle(GetAllPsychologistAccountQueries request, CancellationToken cancellationToken)
    {
        var customerAccount = _context.Get<Domain.Entities.PsychologistAccount>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<PsychologistAccountModel>(customerAccount);

        var page = await PaginatedList<PsychologistAccountModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
