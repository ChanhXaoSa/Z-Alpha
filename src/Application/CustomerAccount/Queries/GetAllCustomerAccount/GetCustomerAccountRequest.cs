using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZAlpha.Application.AnswersForEntranceTest.Queries.GetAnswersForEntranceTest;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;

public class GetCustomerAccountRequest : IRequest<PaginatedList<CustomerAccountModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetCustomerAccountRequestHandler : IRequestHandler<GetCustomerAccountRequest, PaginatedList<CustomerAccountModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerAccountRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CustomerAccountModel>> Handle(GetCustomerAccountRequest request, CancellationToken cancellationToken)
    {
        var customerAccount = _context.Get<Domain.Entities.CustomerAccount>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<CustomerAccountModel>(customerAccount);

        var page = await PaginatedList<CustomerAccountModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}