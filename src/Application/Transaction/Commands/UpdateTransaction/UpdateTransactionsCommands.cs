using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Post.Commands.UpdatePost;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Transaction.Commands.UpdateTransaction;
public class UpdateTransactionsCommands : IRequest<Guid>
{
    public Guid Id { get; set; }
    public TransactionStatus Status { get; set; }
}
public class UpdateTransactionsCommandsHandler : IRequestHandler<UpdateTransactionsCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateTransactionsCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateTransactionsCommands request, CancellationToken cancellationToken)
    {
        var transaction = await _context.Get<Domain.Entities.Transaction>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (transaction == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Transaction), request.Id);
        }

        transaction.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return transaction.Id;
    }
}
