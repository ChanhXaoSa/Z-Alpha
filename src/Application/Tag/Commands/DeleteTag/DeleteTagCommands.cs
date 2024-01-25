using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Comment.Commands.DeleteComment;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.Tag.Commands.DeleteTag;
public class DeleteTagCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeleteTagCommandsHandler : IRequestHandler<DeleteTagCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTagCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTagCommands request, CancellationToken cancellationToken)
    {
        var tag = await _context.Get<Domain.Entities.Tag>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (tag == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Tag), request.Id);
        }
        tag.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
