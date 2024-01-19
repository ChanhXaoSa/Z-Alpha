using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;

public class PsychologistAccountModel : IMapFrom<Domain.Entities.PsychologistAccount>
{
    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
