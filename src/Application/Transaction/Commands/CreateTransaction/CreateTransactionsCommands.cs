using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Post.Commands.CreatePost;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Transaction.Commands.CreateTransaction;
public class CreateTransactionsCommands : IRequest<Guid>
{
    public string UserAccountId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public string? Description { get; set; }
    public float Money { get; set; }
    public float TransactionFee { get; set; }
    public float Balance { get; set; }
    public TransactionStatus Status { get; set; }
}
public class CreateTransactionsCommandsHandler : IRequestHandler<CreateTransactionsCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTransactionsCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTransactionsCommands request,
        CancellationToken cancellationToken)
    {
        var transaction = new Domain.Entities.Transaction()
        {
            UserAccountId = request.UserAccountId,
            PaymentMethodId = request.PaymentMethodId,
            Description = request.Description,
            Money = request.Money,
            TransactionFee = request.TransactionFee,
            Balance = request.Balance,
            Status = request.Status,
        };

        _context.Get<Domain.Entities.Transaction>().Add(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        return transaction.Id;
    }
}
