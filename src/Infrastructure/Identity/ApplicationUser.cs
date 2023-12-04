using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    //public string UserName { get; set; } = null!;
    //public string LastName { get; set; } = null!;
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
