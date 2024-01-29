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
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Transaction.Queries.GetTransaction;

namespace ZAlpha.Application.Transaction.Queries.GetTransactionById;
public class GetTransactionByIdQueries : IRequest<PaginatedList<TransactionModel>>
{
    public string UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetTransactionByIdQueriesHandler : IRequestHandler<GetTransactionByIdQueries, PaginatedList<TransactionModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTransactionByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TransactionModel>> Handle(GetTransactionByIdQueries request, CancellationToken cancellationToken)
    {
        var listTransaction = _context.Get<Domain.Entities.Transaction>()
            .Where(x => x.IsDeleted == false || x.UserAccountId.Equals(request.UserId))
            .Include(x => x.UserAccount)
            .Include(x => x.PaymentMethod)
            .OrderByDescending(o => o.Created)
            .AsNoTracking();

        var map = _mapper.ProjectTo<TransactionModel>(listTransaction);

        var page = await PaginatedList<TransactionModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
