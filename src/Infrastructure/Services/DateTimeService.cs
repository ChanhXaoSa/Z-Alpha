using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
