using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Entities;

namespace ZAlpha.Application.Comment.Queries.GetComment;
public class CommentModel : IMapFrom<Domain.Entities.Comment>
{
    [ForeignKey("Post")]
    public Guid PostId { get; set; }
    //public IList<UserInteractComment>? UserInteractComments { get; private set; }
}


