using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Tag.Queries.GetTag;
public class TagModel : IMapFrom<Domain.Entities.Tag>
{
    public string TagName { get; set; }
    public virtual IList<Domain.Entities.PostTag>? PostTags { get; set; }
}
