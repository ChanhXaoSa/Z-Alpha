using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAlpha.Domain.Entities;
public class EntranceTest : BaseAuditableEntity
{
    [ForeignKey("EntranceTests")]
    public Guid Id { get; set; }
    public string? Question { get; set; }
    public virtual IList<AnswersForEntranceTest>? AnswersForEntranceTests { get; set; }
}
