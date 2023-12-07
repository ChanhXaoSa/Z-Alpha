using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Identity;
public class UserAccount : BaseAuditableEntity
{
    public string? FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public PremiumStatus IsPremium { get; set; }
    public string? Avatar { get; set; }
    public string? AvatarUrl { get; set; }
    public UserStatus Status { get; set; }


    public virtual IList<ManagerAccount>? ManagerAccount { get; set; }
    public virtual IList<CustomerAccount>? CustomerAccount { get; set; }
    public virtual IList<PackInfo>? PackInfo { get; set; }
    public virtual IList<Post>? Posts { get; set; }
    public IList<Transaction>? Transactions { get; private set; }
}
