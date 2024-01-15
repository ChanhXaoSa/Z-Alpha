using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.PackDetail.Commands.UpdatePackDetail;

public record UpdatePackDetailsCommands : IRequest<Guid>
{
    public Guid Id { get; init; }
    public string UserAccountId { get; set; }
    public Guid PackId { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }
}

public class UpdatePackDetailsCommandsHandler : IRequestHandler<UpdatePackDetailsCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdatePackDetailsCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdatePackDetailsCommands request, CancellationToken cancellationToken)
    {
        var packDetail = await _context.Get<Domain.Entities.PackDetail>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (packDetail == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.PackDetail), request.Id);
        }

        packDetail.UserAccountId = request.UserAccountId;
        packDetail.PackId = request.PackId;
        packDetail.StartDay = request.StartDay;
        packDetail.EndDay = request.EndDay;

        await _context.SaveChangesAsync(cancellationToken);

        return packDetail.Id;
    }
}
