using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.AnswersForEntranceTest.Commands.DeleteAnswersForEntranceTest;
public record DeteleAnswersForEntranceTestCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeteleAnswersForEntranceTestCommandsHandler : IRequestHandler<DeteleAnswersForEntranceTestCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeteleAnswersForEntranceTestCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }   

    public async Task<bool> Handle(DeteleAnswersForEntranceTestCommands request, CancellationToken cancellationToken)
    {
        var answers = await _context.Get<Domain.Entities.AnswersForEntranceTest>()
            .FindAsync(new object[] { request.Id}, cancellationToken);

        if(answers == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.AnswersForEntranceTest), request.Id);
        }
        answers.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken); 

        return true;
    }
}
