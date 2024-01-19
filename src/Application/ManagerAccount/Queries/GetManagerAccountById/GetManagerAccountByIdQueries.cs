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
using ZAlpha.Application.Post.Queries.GetPostById;

namespace ZAlpha.Application.ManagerAccount.Queries.GetManagerAccountById;
public class GetManagerAccountByIdQueries : IRequest<GetAllManagerAccount.ManageAccountModel>
{
    public Guid Id { get; set; }
}

public class GetManagerAccountByIdQueriesHandler : IRequestHandler<GetManagerAccountByIdQueries, GetAllManagerAccount.ManageAccountModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetManagerAccountByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<GetAllManagerAccount.ManageAccountModel> Handle(GetManagerAccountByIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var Post = _context.Get<Domain.Entities.ManagerAccount>()
            .Where(x => x.IsDeleted == false && x.Id.Equals(request.Id))
            .Include(o => o.UserAccount)
            .AsNoTracking()
            .FirstOrDefault();
        if (Post == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Post), request.Id);
        }

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.Map<GetAllManagerAccount.ManageAccountModel>(Post);

        // Paginate data
        return Task.FromResult(map); //Task.CompletedTask;
    }
}