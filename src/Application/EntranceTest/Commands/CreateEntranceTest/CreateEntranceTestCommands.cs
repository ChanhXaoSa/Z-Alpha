using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.EntranceTest.Commands.CreateEntranceTest;
public class CreateEntranceTestCommands : IRequest<Guid>
{

}

public class CreateEntranceTestCommandsHandler : IRequestHandler<CreateEntranceTestCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateEntranceTestCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateEntranceTestCommands request, CancellationToken cancellationToken)
    {
        var entranceTest = new Domain.Entities.EntranceTest()
        {
            
        };

        _context.Get<Domain.Entities.EntranceTest>().Add(entranceTest);
        await _context.SaveChangesAsync(cancellationToken);

        return entranceTest.Id;
    }
}
