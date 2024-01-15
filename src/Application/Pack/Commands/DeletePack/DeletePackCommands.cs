using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.Pack.Commands.DeletePack;

public record DeletePackCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeletePackCommandsHandler : IRequestHandler<DeletePackCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePackCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePackCommands request, CancellationToken cancellationToken)
    {
        var pack = await _context.Get<Domain.Entities.Pack>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (pack == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Pack), request.Id);
        }
        pack.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
