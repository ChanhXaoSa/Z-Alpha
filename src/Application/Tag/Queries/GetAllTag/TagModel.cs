using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Tag.Queries.GetTag;
public class TagModel : IMapFrom<Domain.Entities.Tag>
{
    public Guid Id { get; set; }
    public string? TagName { get; set; }
    public DateTime Created { get; set; }
    public virtual IList<Domain.Entities.PostTag>? PostTags { get; set; }
}
