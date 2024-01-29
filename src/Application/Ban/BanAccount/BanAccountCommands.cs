using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.Ban.BanAccount;
public class BanAccountCommands : IRequest<bool>
{
    public string Id { get; init; }
    public UserStatus UserStatus { get; set; }
}
public class BanAccountCommandsCommandsHandler : IRequestHandler<BanAccountCommands, bool>
{
    private readonly IApplicationDbContext _context;

    private readonly IIdentityService _identityService;

    public BanAccountCommandsCommandsHandler(IIdentityService identityService, IApplicationDbContext context)
    {
        _context = context;

        _identityService = identityService;
    }

    public async Task<bool> Handle(BanAccountCommands request, CancellationToken cancellationToken)
    {
        bool isBanned = false;
        var account = await _identityService.GetUserAsync(request.Id);

        if (account != null)
        {
            isBanned = true;
            account.Status = UserStatus.Banned;
        } else
        {
            isBanned = false;
            throw new NotFoundException(nameof(Domain.Entities.CustomerAccount), request.Id);
            
        }       

        await _context.SaveChangesAsync(cancellationToken);

        return isBanned;
    }
}