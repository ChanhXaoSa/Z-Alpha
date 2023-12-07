﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Domain.Entities;
public class Comment : BaseAuditableEntity
{

    [ForeignKey("Post")]
    public Guid PostId { get; set; }
    public virtual Post? Post { get; set; }

    public IList<UserInteractComment>? UserInteractComments { get; private set; }
}
