using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Ban.BanAccount;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Ban.UpdateAvatarUser;
public class UpdateAvatarUserCommands : IRequest<bool>
{
    public string Id { get; init; }
    public string AvatarUrl {  get; init; }
}
public class UpdateAvatarUserCommandsHandler : IRequestHandler<UpdateAvatarUserCommands, bool>
{
    private readonly IApplicationDbContext _context;

    private readonly IIdentityService _identityService;

    public UpdateAvatarUserCommandsHandler(IIdentityService identityService, IApplicationDbContext context)
    {
        _context = context;

        _identityService = identityService;
    }

    public async Task<bool> Handle(UpdateAvatarUserCommands request, CancellationToken cancellationToken)
    {
        bool isUpdate= false;
        var account = await _identityService.GetUserAsync(request.Id);

        if (account != null)
        {
            isUpdate = true;
            account.AvatarUrl = request.AvatarUrl;
        }            
        else
            throw new NotFoundException(nameof(Domain.Entities.CustomerAccount), request.Id);

        await _context.SaveChangesAsync(cancellationToken);

        return isUpdate;
    }
}
