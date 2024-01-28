using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.PsychologistAccount.Commands.UpdatePsychologistAccountCommand;
public class UpdatePsychologistAccountCommand : IRequest<Guid>
{
    public string Id { get; init; }
    public string UserAccountId { get; set; }
    public string? Workplace { get; set; }
    public string? Position { get; set; }   
    public string? Milestone { get; set; }
    public string? Specialization { get; set; } 
    public string? Intro { get; set; }
}

public class UpdatePsychologistAccountCommandHandler : IRequestHandler<UpdatePsychologistAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdatePsychologistAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdatePsychologistAccountCommand request, CancellationToken cancellationToken)
    {
        var psychologist = await _context.Get<Domain.Entities.PsychologistAccount>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (psychologist == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.PsychologistAccount), request.Id);
        }

        psychologist.UserAccountId = request.UserAccountId;
        psychologist.Workplace = request.Workplace;
        psychologist.Position = request.Position;
        psychologist.Milestones = request.Milestone;
        psychologist.Specialize = request.Specialization;
        psychologist.Intro = request.Intro;

        await _context.SaveChangesAsync(cancellationToken);

        return psychologist.Id;
    }
}
