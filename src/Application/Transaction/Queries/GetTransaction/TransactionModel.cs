using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.Transaction.Queries.GetTransaction;
public class TransactionModel : IMapFrom<Domain.Entities.Transaction>
{
    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
    public Guid PaymentMethodId { get; set; }
    public virtual PaymentMethod? PaymentMethod { get; set; }
    public string? Description { get; set; }
    public double Money { get; set; }
    public double TransactionFee { get; set; }
    public double Balance { get; set; }
    public DateTime Created { get; set; }
    public TransactionStatus Status { get; set; }
}
