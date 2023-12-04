using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Tag : BaseAuditableEntity
{
    public string TagName { get; set; }
}
