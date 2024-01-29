using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;

namespace ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
public class GetCustomerAccountByUserIdQueries : IRequest<GetAllCustomerAccount.CustomerAccountModel>
{
    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
}

public class GetCustomerAccountByUserIdQueriesHandler : IRequestHandler<GetCustomerAccountByUserIdQueries, GetAllCustomerAccount.CustomerAccountModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetCustomerAccountByUserIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<GetAllCustomerAccount.CustomerAccountModel> Handle(GetCustomerAccountByUserIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var psychologist = _context.Get<Domain.Entities.CustomerAccount>()
            .Include(x => x.UserAccount)
            .ThenInclude(o => o.WishListPosts)
            .Include(x => x.UserAccount.InteractWithPosts)
            .Include(x => x.UserAccount.InteractWithComments)
            .Where(x => x.IsDeleted == false && x.UserAccountId.Equals(request.UserAccountId))
            .AsNoTracking()
            .FirstOrDefault();
        if (psychologist == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.CustomerAccount), request.UserAccountId);
        }

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.Map<GetAllCustomerAccount.CustomerAccountModel>(psychologist);

        // Paginate data
        return Task.FromResult(map); //Task.CompletedTask;
    }
}