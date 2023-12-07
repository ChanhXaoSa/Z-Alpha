using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Pack : BaseAuditableEntity
{
    public virtual IList<PackInfo>? PackInfos { get; set; }
}
