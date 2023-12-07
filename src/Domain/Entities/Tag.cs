using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class Tag : BaseAuditableEntity
{
    public string TagName { get; set; }
    public virtual IList<PostTag>? PostTags { get; set; }
}
