using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;

namespace ZAlpha.Application.WishListPost;
public class WishListPostModel : IMapFrom<Domain.Entities.WishListPost>
{
    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
    public Guid PostId { get; set; }
    public bool IsDeleted { get; set; }
}
