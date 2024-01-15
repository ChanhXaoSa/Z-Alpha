using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Domain.Entities;
public class Tag : BaseAuditableEntity
{
    public string TagName { get; set; }
    public virtual IList<PostTag>? PostTags { get; set; }
}
