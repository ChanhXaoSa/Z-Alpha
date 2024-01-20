using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Domain.Entities;
public class InteractWithComments :BaseAuditableEntity
{

    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }
    [ForeignKey("Comment")]
    public Guid CommentId { get; set; }
    public virtual Comment Comment { get; set; }
    public InteractCommentStatus? InteractCommentStatus { get; set; }
}
