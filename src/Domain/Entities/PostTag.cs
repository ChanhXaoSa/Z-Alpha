using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class PostTag : BaseAuditableEntity
{
    [ForeignKey("Post")]
    public Guid PostId { get; set; }
    public virtual Post? Post { get; set; }
    [ForeignKey("Tag")]
    public Guid TagId { get; set;}
    public virtual Tag? Tag { get; set; }
}
