using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Pack.Commands.CreatePack;

public class CreatePackCommands : IRequest<Guid>
{
    public string PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
}

public class CreatePackCommandsHandler : IRequestHandler<CreatePackCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePackCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePackCommands request, CancellationToken cancellationToken)
    {
        var pack = new Domain.Entities.Pack()
        {
            PackName = request.PackName,
            PackInfomation = request.PackInfomation,
            PackPrice = request.PackPrice
        };

        _context.Get<Domain.Entities.Pack>().Add(pack);
        await _context.SaveChangesAsync(cancellationToken);

        return pack.Id;
    }
}
