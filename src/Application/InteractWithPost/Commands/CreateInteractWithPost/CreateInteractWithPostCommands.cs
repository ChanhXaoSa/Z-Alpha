using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.InteractWithPost.Commands.CreateInteractWithPost;
public class CreateInteractWithPostCommands : IRequest<Guid>
{
    public string UserAccountId { get; set; }
    public Guid PostId { get; set; }
    public InteractPostStatus InteractPostStatus { get; set; }
}

public class CreateInteractWithPostCommandsHandler : IRequestHandler<CreateInteractWithPostCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateInteractWithPostCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateInteractWithPostCommands request, CancellationToken cancellationToken)
    {
        var checker = await _context.Get<Domain.Entities.InteractWithPosts>()
            .FirstOrDefaultAsync( i => i.PostId == request.PostId && i.UserAccountId == request.UserAccountId && i.InteractPostStatus != InteractPostStatus.Create, cancellationToken);
        if (checker != null)
        {
            if (checker.InteractPostStatus == InteractPostStatus.Create)
            {
                return checker.Id;
            }
            checker.InteractPostStatus = request.InteractPostStatus;
            await _context.SaveChangesAsync(cancellationToken);
            return checker.Id;
        }
        else
        {
            if (request.InteractPostStatus == InteractPostStatus.Create)
            {
                throw new Exception();
            }
            var interactWithPost = new Domain.Entities.InteractWithPosts()
            {
                UserAccountId = request.UserAccountId,
                PostId = request.PostId,
                InteractPostStatus = request.InteractPostStatus,
            };

            _context.Get<Domain.Entities.InteractWithPosts>().Add(interactWithPost);
            await _context.SaveChangesAsync(cancellationToken);

            return interactWithPost.Id;
        }
    }
}
