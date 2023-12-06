using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    public virtual UserAccount UserAccount { get; set; }
}
