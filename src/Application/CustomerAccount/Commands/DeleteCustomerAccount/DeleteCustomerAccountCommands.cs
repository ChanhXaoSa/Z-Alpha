using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.AnswersForEntranceTest.Commands.DeleteAnswersForEntranceTest;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CustomerAccount.Commands.DeleteCustomerAccount;
public record DeleteCustomerAccountCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeleteCustomerAccountCommandsHandler : IRequestHandler<DeleteCustomerAccountCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCustomerAccountCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCustomerAccountCommands request, CancellationToken cancellationToken)
    {
        var customer = await _context.Get<Domain.Entities.CustomerAccount>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (customer == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.CustomerAccount), request.Id);
        }
        customer.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
