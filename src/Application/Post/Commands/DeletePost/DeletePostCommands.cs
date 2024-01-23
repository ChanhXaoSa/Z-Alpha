using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.Post.Commands.DeletePost;
public class DeletePostCommands : IRequest<bool>
{
    public Guid Id { get; init; }
}
public class DeletePostCommandshandler : IRequestHandler<DeletePostCommands, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePostCommandshandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePostCommands request, CancellationToken cancellationToken)
    {
        var post = await _context.Get<Domain.Entities.Post>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (post == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.CustomerAccount), request.Id);
        }
        post.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}