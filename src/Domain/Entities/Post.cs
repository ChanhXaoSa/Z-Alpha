using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class Post : BaseAuditableEntity
{
    // Đang bị vòng nên k dùng như v dc
    /*[ForeignKey("UserAccount")]
    public Guid UserAccountId { get; set; }
    public virtual UserAccount? UserAccount { get; set; }*/
    

    public string PostTitle { get; set; }
    public string PostBody { get; set; }
    public string? PostImagesUrl { get; set; }
    public int? NumberOfLikes { get; set; }
    public int? NumberOfDisLikes { get; set; }
    public AnonymousStatus AnonymousStatus { get; set; }
    public IList<PostTag>? PostTags { get;  set; }
    public IList<InteractWithPosts>? InteractWithPosts { get;  set; }
    public IList<WishListPost>? WishListPosts { get;  set; }
    public IList<Comment>? Comments { get;  set; }
}
    