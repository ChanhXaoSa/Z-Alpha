using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CleanArchitecture.Domain.Identity;
public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public PremiumStatus IsPremium { get; set; }
    public string? Avatar { get; set; }
    public string? AvatarUrl { get; set; }
    public UserStatus Status { get; set; }

    public Guid? ManagerAccountId { get; set; }
    public virtual ManagerAccount? ManagerAccount { get; set; }
    public IList<Transaction>? Transactions { get; private set; }
}
