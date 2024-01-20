using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Domain.Entities;
public class PsychologistAccount : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public string? Specialize {get; set; }
    public string? Workplace { get; set; }   
    public string? Position { get; set; }
    public string? Milestones { get; set; }
    public string? Intro { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
