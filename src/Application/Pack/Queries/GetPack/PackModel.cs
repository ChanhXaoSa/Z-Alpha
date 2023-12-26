using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.Pack.Queries.GetPack;
public class PackModel : IMapFrom<Domain.Entities.Pack>
{
    public string PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
}
