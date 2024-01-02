using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.AnswersForEntranceTest.Commands.CreateAnswersForEntranceTest;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CustomerAccount.Commands.CreateCustomerAccount;
public class CreateCustomerAccountCommands : IRequest<string>
{
    public string UserAccountId { get; set; }
}

public class CreateCustomerAccountCommandsHandler : IRequestHandler<CreateCustomerAccountCommands, string>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomerAccountCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreateCustomerAccountCommands request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.CustomerAccount()
        {
            UserAccountId = request.UserAccountId,
        };

        _context.Get<Domain.Entities.CustomerAccount>().Add(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return customer.Id.ToString();
    }
}
