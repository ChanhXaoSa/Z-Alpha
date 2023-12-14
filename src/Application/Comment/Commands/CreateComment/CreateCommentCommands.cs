using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Comment.Commands.CreateComment;
public class CreateCommentCommands : IRequest<Guid>
{
    public Guid PostId { get; set; }
    public IList<UserInteractComment>? UserInteractComments { get; private set; }
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
            
        };

        _context.Get<Domain.Entities.Comment>().Add(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return comment.Id;
    }
}
