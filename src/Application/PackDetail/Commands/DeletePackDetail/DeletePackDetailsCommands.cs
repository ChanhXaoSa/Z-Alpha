using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.PackDetail.Commands.DeletePackDetail;

public record DeletePackDetailsCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeletePackDetailsCommandsHandler : IRequestHandler<DeletePackDetailsCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePackDetailsCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePackDetailsCommands request, CancellationToken cancellationToken)
    {
        var packDetail = await _context.Get<Domain.Entities.PackDetail>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (packDetail == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.PackDetail), request.Id);
        }
        packDetail.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

