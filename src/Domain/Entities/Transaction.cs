using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class Transaction : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
    [ForeignKey("PaymentMethod")]
    public Guid PaymentMethodId { get; set; }
    public virtual PaymentMethod? PaymentMethod { get; set; }
    public string? Description { get; set; }
    public double Money { get; set; }
    public double TransactionFee { get; set; }
    public double Balance { get; set; }
}
