﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class UserInteractComment : BaseAuditableEntity
{

    [ForeignKey("UserAccount")]
    public string UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }
    [ForeignKey("Comment")]
    public Guid CommentId { get; set; }
    public virtual Comment? Comment { get; set; }
    public InteractComment InteractComment { get; set; }
    public string Description { get; set; }
}
