using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CleanArchitecture.Domain.Identity;


namespace CleanArchitecture.Domain.Entities;
public class UserAccount : BaseAuditableEntity
{
    [ForeignKey("ApplicationUser")]
    public string ApplicationUserId { get; set; }
    public string? FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public PremiumStatus IsPremium { get; set; }
    public string? Avatar { get; set; }
    public string? AvatarUrl { get; set; }
    public UserStatus Status { get; set; }


    public virtual ManagerAccount? ManagerAccount { get; set; }
    public IList<Transaction>? Transactions { get; private set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
}
