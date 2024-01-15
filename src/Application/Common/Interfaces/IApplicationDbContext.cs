using ZAlpha.Domain.Common;
using ZAlpha.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    DbSet<T> Get<T>() where T : BaseAuditableEntity;
}
