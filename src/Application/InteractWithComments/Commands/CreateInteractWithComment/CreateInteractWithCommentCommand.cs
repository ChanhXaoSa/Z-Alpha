using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
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
