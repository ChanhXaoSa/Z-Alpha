using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.Comment.Commands.CreateComment;
public class CreateCommentCommands : IRequest<Guid>
{
    public string UserAccountId { get; set; }
    public Guid? ReplyCommentId { get; set; }
    public Guid PostId { get; set; }
    public string Description { get; set; }
}

public class CreateCommentCommandsHandler : IRequestHandler<CreateCommentCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCommentCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCommentCommands request, CancellationToken cancellationToken)
    {
        var comment = new Domain.Entities.Comment()
        {
            UserAccountId = request.UserAccountId,
            ReplyCommentId = request.ReplyCommentId,
            Description = request.Description,
            PostId = request.PostId
        };

        _context.Get<Domain.Entities.Comment>().Add(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return comment.Id;
    }
}
