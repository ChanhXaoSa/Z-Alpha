using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Comment.Commands.DeleteComment;
public record DeleteCommentCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeleteCommentCommandsHandler : IRequestHandler<DeleteCommentCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCommentCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCommentCommands request, CancellationToken cancellationToken)
    {
        var comment = await _context.Get<Domain.Entities.Comment>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (comment == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
        }
        comment.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
