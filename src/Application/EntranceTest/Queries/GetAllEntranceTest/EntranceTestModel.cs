using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;

namespace ZAlpha.Application.EntranceTest.Queries.GetAllEntranceTest;
public class EntranceTestModel : IMapFrom<Domain.Entities.EntranceTest>
{
    public string? Question { get; set; }
}
