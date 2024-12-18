﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAlpha.Domain.Entities;
public class AnswersForEntranceTest : BaseAuditableEntity
{
    [ForeignKey("EntranceTest")]
    public Guid EntranceTestId { get; set; }
    public string? Answer { get; set; }
    public bool? IsCorrect { get; set; }
    [ForeignKey("CustomerAccount")]
    public Guid CustomerAccountId { get; set; }
    public virtual CustomerAccount? CustomerAccount { get; set; }
}
