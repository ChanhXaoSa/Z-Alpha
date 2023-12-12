using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.AnswersForEntranceTest.Commands.UpdateAnswersForEntranceTest;
public record UpdateAnswersForEntranceTestCommands : IRequest<Guid>
{
    public Guid Id { get; init; }
    public Guid EntranceTestId { get; set; }
    public string? Answer { get; set; }
    public Guid CustomerAccountId { get; set; }
}

public class UpdateAnswersForEntranceTestCommandsHandler : IRequestHandler<UpdateAnswersForEntranceTestCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateAnswersForEntranceTestCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }   

    public async Task<Guid> Handle(UpdateAnswersForEntranceTestCommands request, CancellationToken cancellationToken)
    {
        var answers = await _context.Get<Domain.Entities.AnswersForEntranceTest>()
            .FindAsync(new object[] {request.Id}, cancellationToken);

        if(answers == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.AnswersForEntranceTest), request.Id);
        }

        answers.EntranceTestId = request.Id;
        answers.Answer = request.Answer;
        answers.CustomerAccountId = request.CustomerAccountId;

        await _context.SaveChangesAsync(cancellationToken);

        return answers.Id;
    }
}
