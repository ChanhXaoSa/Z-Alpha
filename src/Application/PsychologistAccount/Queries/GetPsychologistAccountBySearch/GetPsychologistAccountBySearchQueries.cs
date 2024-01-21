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
using ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;

namespace ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistAccountBySearch;
public class GetPsychologistAccountBySearchQueries : IRequest<PaginatedList<PsychologistAccountModel>>
{
    public int Page { get; set; }
    public string KeySearch { get; set; }
    public int Size { get; set; }
}

public class GetPsychologistAccountBySearchQueriesHandler : IRequestHandler<GetPsychologistAccountBySearchQueries, PaginatedList<PsychologistAccountModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPsychologistAccountBySearchQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PsychologistAccountModel>> Handle(GetPsychologistAccountBySearchQueries request, CancellationToken cancellationToken)
    {
        var customerAccount = _context.Get<Domain.Entities.PsychologistAccount>()
            .Where(x => x.IsDeleted == false
            && x.UserAccount.FirstName.Contains(request.KeySearch)
            || x.UserAccount.LastName.Contains(request.KeySearch)
            || x.UserAccount.UserName.Contains(request.KeySearch)).AsNoTracking();

        var map = _mapper.ProjectTo<PsychologistAccountModel>(customerAccount);

        var page = await PaginatedList<PsychologistAccountModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}