using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ZAlpha.Domain.Identity;
public class UserAccount : IdentityUser
{
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDay { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public PremiumStatus? IsPremium { get; set; }
    public string? Avatar { get; set; }
    public string? AvatarUrl { get; set; }
    public Double Wallet { get; set; }
    public UserStatus Status { get; set; }


    public virtual IList<ManagerAccount>? ManagerAccounts { get; set; }
    public virtual IList<CustomerAccount>? CustomerAccounts { get; set; }
    public virtual IList<PackDetail>? PackDetails { get; set; }
    // Bị vòng
    //public virtual IList<Post>? Posts { get; set; }
    public IList<Transaction>? Transactions { get;  set; }
    public IList<InteractWithPosts>? InteractWithPosts { get;  set; }
    public IList<WishListPost>? WishListPosts { get;  set; }
    public IList<Comment>? Comments { get; set; }
    //public IList<UserInteractComment>? UserInteractComments { get; set; }
}
