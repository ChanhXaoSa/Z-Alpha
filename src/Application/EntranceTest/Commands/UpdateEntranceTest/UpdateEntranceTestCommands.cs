using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.EntranceTest.Commands.UpdateEntranceTest;

public record UpdateEntranceTestCommands : IRequest<Guid>
{
    public Guid Id { get; init; }
}

public class UpdateEntranceTestCommandsHandler : IRequestHandler<UpdateEntranceTestCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateEntranceTestCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateEntranceTestCommands request, CancellationToken cancellationToken)
    {
        var entranceTest = await _context.Get<Domain.Entities.EntranceTest>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entranceTest == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.EntranceTest), request.Id);
        }

        

        await _context.SaveChangesAsync(cancellationToken);

        return entranceTest.Id;
    }
}
