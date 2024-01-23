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

namespace ZAlpha.Application.ManagerAccount.Queries.GetAllManagerAccount;
public class GetManagerAccountQueries : IRequest<PaginatedList<ManageAccountModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetManagerAccountQueriesHandler : IRequestHandler<GetManagerAccountQueries, PaginatedList<ManageAccountModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetManagerAccountQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ManageAccountModel>> Handle(GetManagerAccountQueries request, CancellationToken cancellationToken)
    {
        var managerAccount = _context.Get<Domain.Entities.ManagerAccount>()
            .Include(x => x.UserAccount)
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<ManageAccountModel>(managerAccount);

        var page = await PaginatedList<ManageAccountModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}