using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Comment.Commands.UpdateComment;
public record UpdateCommentCommands : IRequest<Guid>
{
    public Guid Id { get; init; }
    public Guid PostId { get; set; }
    //public IList<UserInteractComment>? UserInteractComments { get; private set; }
}

public class UpdateCommentCommandsHandler : IRequestHandler<UpdateCommentCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateCommentCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateCommentCommands request, CancellationToken cancellationToken)
    {
        var customer = await _context.Get<Domain.Entities.Comment>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (customer == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
        }

        customer.PostId = request.PostId;

        await _context.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
