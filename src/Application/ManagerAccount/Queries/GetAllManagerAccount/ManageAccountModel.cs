using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.ManagerAccount.Queries.GetAllManagerAccount;

public class ManageAccountModel : IMapFrom<Domain.Entities.ManagerAccount>
{
    public Guid Id { get; set; }
    public string UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
