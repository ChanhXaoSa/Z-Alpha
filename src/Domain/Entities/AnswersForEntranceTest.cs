using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class AnswersForEntranceTest : BaseAuditableEntity
{
    [ForeignKey("EntranceTest")]
    public Guid EntranceTestId { get; set; }
    public string? Answer { get; set; } 
}
