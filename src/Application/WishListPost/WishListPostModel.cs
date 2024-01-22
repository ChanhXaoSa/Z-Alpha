using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.WishListPost;
public class WishListPostModel : IMapFrom<Domain.Entities.WishListPost>
{
    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
    public Guid PostId { get; set; }
    public Domain.Entities.Post post { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
    public bool IsDeleted { get; set; }
}
