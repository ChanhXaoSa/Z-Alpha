using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Domain.Entities;
public class InteractWithPosts : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }
    [ForeignKey("Post")]
    public Guid PostId { get; set; }
    public virtual Post Post { get; set; }
    public InteractPostStatus? InteractPostStatus { get; set; }
}
