using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;
public class CustomerAccountModel : IMapFrom<Domain.Entities.CustomerAccount>
{
    public Guid Id { get; set; }
    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
