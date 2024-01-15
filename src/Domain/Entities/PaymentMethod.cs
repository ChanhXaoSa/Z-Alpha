using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAlpha.Domain.Entities;
public class PaymentMethod : BaseAuditableEntity
{
    public string PaymentMethodName { get; set; }
    public PaymentMethodStatus PaymentMethodStatus { get; set; }
    public virtual IList<Transaction>? Transactions { get; set; }
}
