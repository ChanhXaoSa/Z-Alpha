using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class PackInfo : BaseAuditableEntity
{
    public string? PackName { get; set; }
    public string? PackInfomation { get; set; }
    public double? PackPrice { get; set; }
    public PackStatus PackStatus { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }

    public IList<Pack>? PostTags { get; private set; }
    public IList<ManagerAccount>? ManagerAccounts { get; private set; }
}
