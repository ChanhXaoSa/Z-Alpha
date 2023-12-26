using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Application.CustomerAccount.Queries.GetAllCustomerAccount;
public class CustomerAccountModel : IMapFrom<Domain.Entities.CustomerAccount>
{
    public Guid Id { get; set; }
    [ForeignKey("UserAccount")]
    public Guid UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }
}
