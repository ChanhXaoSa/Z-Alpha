using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class PaymentMethod : BaseAuditableEntity
{
    public virtual IList<Transaction>? Transaction { get; set; }
}
