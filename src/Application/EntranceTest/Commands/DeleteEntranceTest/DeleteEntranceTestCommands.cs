using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.EntranceTest.Commands.DeleteEntranceTest;

public record DeleteEntranceTestCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeleteEntranceTestCommandsHandler : IRequestHandler<DeleteEntranceTestCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEntranceTestCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEntranceTestCommands request, CancellationToken cancellationToken)
    {
        var entranceTest = await _context.Get<Domain.Entities.EntranceTest>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entranceTest == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.EntranceTest), request.Id);
        }
        entranceTest.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
