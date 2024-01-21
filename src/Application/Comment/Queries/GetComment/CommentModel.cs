using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.Comment.Queries.GetComment;
public class CommentModel : IMapFrom<Domain.Entities.Comment>
{
    public Guid Id { get; set; }
    public Guid? ReplyCommentId { get; set; }
    public virtual ZAlpha.Domain.Entities.Comment Comment { get; set; }
    public Guid PostId { get; set; }
    public virtual ZAlpha.Domain.Entities.Post Post { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public IList<ZAlpha.Domain.Entities.InteractWithComments>? InteractWithComments { get; set; }
}


