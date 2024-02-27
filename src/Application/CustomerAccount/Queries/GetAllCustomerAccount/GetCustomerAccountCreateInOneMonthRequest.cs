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

namespace ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;
public class GetCustomerAccountCreateInOneMonthRequest : IRequest<PaginatedList<CustomerAccountModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetCustomerAccountCreateInOneMonthRequestHandler : IRequestHandler<GetCustomerAccountCreateInOneMonthRequest, PaginatedList<CustomerAccountModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerAccountCreateInOneMonthRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CustomerAccountModel>> Handle(GetCustomerAccountCreateInOneMonthRequest request, CancellationToken cancellationToken)
    {
        var customerAccount = _context.Get<Domain.Entities.CustomerAccount>()
            .Include(x => x.UserAccount)
            .Include(x => x.UserAccount.InteractWithPosts)
            .Include(x => x.UserAccount.InteractWithComments)
            .Where(x => x.IsDeleted == false && x.Created.Month == DateTime.Now.Month).AsNoTracking();

        var map = _mapper.ProjectTo<CustomerAccountModel>(customerAccount);

        var page = await PaginatedList<CustomerAccountModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
