using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.InteractWithPost.Commands.CreateInteractWithPost;
public class CreateInteractWithPostCommand : IRequest<Guid>
{
    public string UserAccountId { get; set; }
    public Guid PostId { get; set; }
    public InteractPostStatus InteractPostStatus { get; set; }
}
public class CreateInteractWithPostCommandHandler : IRequestHandler<CreateInteractWithPostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateInteractWithPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateInteractWithPostCommand request, CancellationToken cancellationToken)
    {
        var interactWithPost = new Domain.Entities.InteractWithPosts()
        {
            UserAccountId = request.UserAccountId,
            PostId = request.PostId,
            InteractPostStatus = request.InteractPostStatus
        };
        _context.Get<Domain.Entities.InteractWithPosts>().Add(interactWithPost);
        await _context.SaveChangesAsync(cancellationToken);

        return interactWithPost.Id;
    }
}