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
using ZAlpha.Application.ManagerAccount.Queries.GetManagerAccountById;

namespace ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;
public class GetPsychologistAccountByUserIdQueries : IRequest<GetAllPsychologistAccount.PsychologistAccountModel>
{
    public Guid Id { get; set; }
}

public class GetPsychologistAccountByUserIdQueriesHandler : IRequestHandler<GetPsychologistAccountByUserIdQueries, GetAllPsychologistAccount.PsychologistAccountModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetPsychologistAccountByUserIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<GetAllPsychologistAccount.PsychologistAccountModel> Handle(GetPsychologistAccountByUserIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var Post = _context.Get<Domain.Entities.PsychologistAccount>()
            .Where(x => x.IsDeleted == false && x.UserAccountId.Equals(request.Id))
            .Include(o => o.UserAccount)
            .AsNoTracking()
            .FirstOrDefault();                      
        if (Post == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.PsychologistAccount), request.Id);
        }

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.Map<GetAllPsychologistAccount.PsychologistAccountModel>(Post);

        // Paginate data
        return Task.FromResult(map); //Task.CompletedTask;
    }
}
