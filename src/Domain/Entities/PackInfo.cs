using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class PackInfo : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public Guid UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
    [ForeignKey("Pack")]
    public Guid PackId { get; set; }
    public virtual Pack? Pack { get; set; }


    public string? PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
    public PackStatus PackStatus { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }

}
