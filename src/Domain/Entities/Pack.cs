using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Pack : BaseAuditableEntity
{

    public string PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
   
    public virtual IList<PackDetail>? PackDetails { get; set; }
}
