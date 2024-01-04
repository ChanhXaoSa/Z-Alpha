﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Identity;

namespace CleanArchitecture.Application.PackDetail.Queries.GetPackDetail;
public class PackDetailsModel : IMapFrom<Domain.Entities.PackDetail>
{
    public Guid UserAccountId { get; set; }
    public Guid PackId { get; set; }

    //public PackStatus PackStatus { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }
}