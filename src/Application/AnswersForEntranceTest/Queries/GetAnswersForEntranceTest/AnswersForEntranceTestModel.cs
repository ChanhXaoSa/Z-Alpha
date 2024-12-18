﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;

namespace ZAlpha.Application.AnswersForEntranceTest.Queries.GetAnswersForEntranceTest;
public class AnswersForEntranceTestModel : IMapFrom<Domain.Entities.AnswersForEntranceTest>
{
    [ForeignKey("EntranceTest")]
    public Guid EntranceTestId { get; set; }
    public string? Answer { get; set; }
    public bool? IsCorrect { get; set; }
    public DateTime Created { get; set; }
    [ForeignKey("CustomerAccount")]
    public Guid CustomerAccountId { get; set; }
}
