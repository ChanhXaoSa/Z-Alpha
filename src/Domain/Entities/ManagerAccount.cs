using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class ManagerAccount : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public Guid UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }

    public IList<Comment>? Comments { get; private set; }
    public IList<Post>? Posts { get; private set; }
    public IList<WishListPost>? WishListPosts { get; private set; }
}
