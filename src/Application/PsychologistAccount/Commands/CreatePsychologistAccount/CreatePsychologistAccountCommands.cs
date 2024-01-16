using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistAccount;
public class CreatePsychologistAccountCommands : IRequest<string>
{
    public string UserAccountId { get; set; }
}

public class CreatePsychologistAccountCommandsHandler : IRequestHandler<CreatePsychologistAccountCommands, string>
{
    private readonly IApplicationDbContext _context;

    public CreatePsychologistAccountCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreatePsychologistAccountCommands request, CancellationToken cancellationToken)
    {
        var psychologist = new Domain.Entities.PsychologistAccount()
        {
            UserAccountId = request.UserAccountId,
        };

        _context.Get<Domain.Entities.PsychologistAccount>().Add(psychologist);
        await _context.SaveChangesAsync(cancellationToken);

        return psychologist.Id.ToString();
    }
}
