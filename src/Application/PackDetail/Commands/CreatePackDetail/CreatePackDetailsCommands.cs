using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.PackDetail.Commands.CreatePackDetail;

public class CreatePackDetailsCommands : IRequest<Guid>
{
    public Guid UserAccountId { get; set; }
    public Guid PackId { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }
}

public class CreatePackDetailsCommandsHandler : IRequestHandler<CreatePackDetailsCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePackDetailsCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePackDetailsCommands request, CancellationToken cancellationToken)
    {
        var packDetail = new Domain.Entities.PackDetail()
        {
            UserAccountId = request.UserAccountId,
            PackId = request.PackId,
            StartDay = request.StartDay,
            EndDay = request.EndDay,    
        };

        _context.Get<Domain.Entities.PackDetail>().Add(packDetail);
        await _context.SaveChangesAsync(cancellationToken);

        return packDetail.Id;
    }
}
