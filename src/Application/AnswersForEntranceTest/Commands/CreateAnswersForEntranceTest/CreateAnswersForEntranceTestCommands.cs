﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.AnswersForEntranceTest.Commands.CreateAnswersForEntranceTest;
public class CreateAnswersForEntranceTestCommands : IRequest<Guid>
{
    public Guid EntranceTestId { get; set; }
    public string? Answer { get; set; }
    public Guid CustomerAccountId { get; set; }
}

public class CreateAnswersForEntranceTestCommandsHandler : IRequestHandler<CreateAnswersForEntranceTestCommands, Guid>
{ 
    private readonly IApplicationDbContext _context;

    public CreateAnswersForEntranceTestCommandsHandler(IApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<Guid> Handle(CreateAnswersForEntranceTestCommands request, CancellationToken cancellationToken)
    {
        var answers = new Domain.Entities.AnswersForEntranceTest()
        {
            EntranceTestId = request.EntranceTestId,
            Answer = request.Answer,
            CustomerAccountId = request.CustomerAccountId,           
        };

        _context.Get<Domain.Entities.AnswersForEntranceTest>().Add(answers);
        await _context.SaveChangesAsync(cancellationToken);

        return answers.Id;
    }
}