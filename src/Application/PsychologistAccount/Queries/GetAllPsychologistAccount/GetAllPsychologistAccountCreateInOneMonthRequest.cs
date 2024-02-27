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

namespace ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;
public class GetAllPsychologistAccountCreateInOneMonthRequest : IRequest<PaginatedList<PsychologistAccountModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetAllPsychologistAccountCreateInOneMonthRequestHandler : IRequestHandler<GetAllPsychologistAccountCreateInOneMonthRequest, PaginatedList<PsychologistAccountModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPsychologistAccountCreateInOneMonthRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PsychologistAccountModel>> Handle(GetAllPsychologistAccountCreateInOneMonthRequest request, CancellationToken cancellationToken)
    {
        var psychologistAccount = _context.Get<Domain.Entities.PsychologistAccount>()
            .Include(x => x.UserAccount)
            .Include(x => x.UserAccount.InteractWithPosts)
            .Include(x => x.UserAccount.InteractWithComments)
            .Where(x => x.IsDeleted == false && x.Created.Month == DateTime.Now.Month).AsNoTracking();

        var map = _mapper.ProjectTo<PsychologistAccountModel>(psychologistAccount);

        var page = await PaginatedList<PsychologistAccountModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}


