using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class EntranceTest : BaseAuditableEntity
{
    // Chưa làm nha
    public virtual IList<AnswersForEntranceTest>? AnswersForEntranceTests { get; set; }
}
