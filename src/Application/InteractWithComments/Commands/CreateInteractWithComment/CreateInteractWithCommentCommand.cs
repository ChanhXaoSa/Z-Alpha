using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.InteractWithComments.Commands.CreateInteractWithComment;
public class CreateInteractWithCommentCommand : IRequest<Guid>
{
    public string UserAccountId { get; set; }
    public Guid CommentId { get; set; }
    public InteractCommentStatus InteractCommentStatus { get; set; }
}

public class CreateInteractWithCommentCommandHandler : IRequestHandler<CreateInteractWithCommentCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateInteractWithCommentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateInteractWithCommentCommand request, CancellationToken cancellationToken)
    {
        var checker = await _context.Get<Domain.Entities.InteractWithComments>()
            .FirstOrDefaultAsync(i => i.CommentId == request.CommentId && i.UserAccountId == request.UserAccountId, cancellationToken);
        if (checker != null)
        {
            if (checker.InteractCommentStatus == InteractCommentStatus.Create)
            {
                return checker.Id;
            }
            checker.InteractCommentStatus = request.InteractCommentStatus;
            await _context.SaveChangesAsync(cancellationToken);
            return checker.Id;
        }
        else
        {
            var interactWithComment = new Domain.Entities.InteractWithComments()
            {
                UserAccountId = request.UserAccountId,
                CommentId = request.CommentId,
                InteractCommentStatus = request.InteractCommentStatus
            };

            _context.Get<Domain.Entities.InteractWithComments>().Add(interactWithComment);
            await _context.SaveChangesAsync(cancellationToken);

            return interactWithComment.Id;
        }
    }
}
