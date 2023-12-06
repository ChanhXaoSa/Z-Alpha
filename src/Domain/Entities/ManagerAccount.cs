using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class ManagerAccount : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public Guid UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
