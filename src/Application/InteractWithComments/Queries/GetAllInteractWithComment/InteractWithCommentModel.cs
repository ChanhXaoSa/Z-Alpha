using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.InteractWithComments.Queries.GetAllInteractWithComment;
public class InteractWithCommentModel : IMapFrom<Domain.Entities.InteractWithComments>
{

    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }
    public Guid CommentId { get; set; }
    public virtual Domain.Entities.Comment Comment { get; set; }
    public InteractCommentStatus? InteractCommentStatus { get; set; }
}
