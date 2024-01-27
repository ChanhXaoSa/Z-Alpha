using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Domain.Entities;
public class PackDetail : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
    [ForeignKey("Pack")]
    public Guid PackId { get; set; }
    public virtual Pack? Pack { get; set; }

    // #
    //public PackStatus PackStatus { get; set; }
    public DateTime? StartDay { get; set; }
    public DateTime? EndDay { get; set; }

}
