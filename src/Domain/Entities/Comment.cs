using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Comment : BaseAuditableEntity
{
    [ForeignKey("ApplicationUser")]
    public Guid ApplicationUserId { get; set; }
    [ForeignKey("Post")]
    public Guid? PostId { get; set; }   
    public string? CommentContent { get; set; }
}
