using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;

namespace ZAlpha.Application.Pack.Queries.GetPack;
public class PackModel : IMapFrom<Domain.Entities.Pack>
{
    public string PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
}
