using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Domain.Entities;
public class Comment : BaseAuditableEntity
{

    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }
    [ForeignKey("Comment")]
    public Guid? ReplyCommentId { get; set; }
    public virtual Comment? ReplyComment { get; set; }

    [ForeignKey("Post")]
    public Guid PostId { get; set; }
    public virtual Post? Post { get; set; }



    public string Description { get; set; }

    

    
}
