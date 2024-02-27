using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.PackDetail.Queries.GetPackDetail;
public class PackDetailsModel : IMapFrom<Domain.Entities.PackDetail>
{
    public string UserAccountId { get; set; }
    public Guid PackId { get; set; }
    public Domain.Entities.Pack Pack { get; set; }
    public DateTime? StartDay { get; set; }
    public DateTime? EndDay { get; set; }
}
