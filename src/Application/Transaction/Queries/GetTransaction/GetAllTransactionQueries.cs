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
using ZAlpha.Application.Tag.Queries.GetTag;
using ZAlpha.Application.Transaction.Queries.GetTransaction;

namespace ZAlpha.Application.Transaction.Queries.GetAllTransaction;
public class GetAllTransactionQueries : IRequest<PaginatedList<TransactionModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllTransactionQueriesHandler : IRequestHandler<GetAllTransactionQueries, PaginatedList<TransactionModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTransactionQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TransactionModel>> Handle(GetAllTransactionQueries request, CancellationToken cancellationToken)
    {
        var tags = _context.Get<Domain.Entities.Transaction>()
            .Include(x => x.UserAccount)
            .Include(x => x.PaymentMethod)
            .OrderByDescending(o => o.Created)
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<TransactionModel>(tags);

        var page = await PaginatedList<TransactionModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
