using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPost;
public class InteractWithPostModel : IMapFrom<Domain.Entities.InteractWithPosts>
{
    public string UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }
    public Guid PostId { get; set; }
    public  Domain.Entities.Post post { get; set; }
    public InteractPostStatus? InteractPostStatus { get; set; }
}
