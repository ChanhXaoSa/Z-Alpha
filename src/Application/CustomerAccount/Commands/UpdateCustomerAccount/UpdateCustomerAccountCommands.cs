using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.AnswersForEntranceTest.Commands.UpdateAnswersForEntranceTest;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using MediatR;

namespace ZAlpha.Application.CustomerAccount.Commands.UpdateCustomerAccount;
public record UpdateCustomerAccountCommands : IRequest<string>
{
    public string Id { get; init; }
    public string UserAccountId { get; set; }
}

public class UpdateCustomerAccountCommandsHandler : IRequestHandler<UpdateCustomerAccountCommands, string>
{
    private readonly IApplicationDbContext _context;

    public UpdateCustomerAccountCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UpdateCustomerAccountCommands request, CancellationToken cancellationToken)
    {
        var customer = await _context.Get<Domain.Entities.CustomerAccount>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (customer == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.CustomerAccount), request.Id);
        }

        customer.UserAccountId = request.UserAccountId;

        await _context.SaveChangesAsync(cancellationToken);

        return customer.Id.ToString();
    }
}
