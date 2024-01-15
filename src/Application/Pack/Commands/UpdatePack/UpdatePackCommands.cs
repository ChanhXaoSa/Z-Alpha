using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.Pack.Commands.UpdatePack;

public record UpdatePackCommands : IRequest<Guid>
{
    public Guid Id { get; init; }
    public string PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
}

public class UpdatePackCommandsHandler : IRequestHandler<UpdatePackCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdatePackCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdatePackCommands request, CancellationToken cancellationToken)
    {
        var pack = await _context.Get<Domain.Entities.Pack>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (pack == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Pack), request.Id);
        }

        pack.PackName = request.PackName;
        pack.PackInfomation = request.PackInfomation;
        pack.PackPrice = request.PackPrice;

        await _context.SaveChangesAsync(cancellationToken);

        return pack.Id;
    }
}