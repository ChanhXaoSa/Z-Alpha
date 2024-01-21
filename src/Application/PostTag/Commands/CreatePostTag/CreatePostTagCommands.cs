using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Post.Commands.CreatePost;

namespace ZAlpha.Application.PostTag.Commands.CreatePostTag;
public class CreatePostTagCommands : IRequest<Guid>
{
    public Guid postID { get; set; }
    public Guid TagID { get; set;}
}

public class CreatePostTagCommandsHandler : IRequestHandler<CreatePostTagCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePostTagCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePostTagCommands request, CancellationToken cancellationToken)
    {
        var postTag = new Domain.Entities.PostTag()
        {
            PostId = request.postID,
            TagId = request.TagID
        };

        _context.Get<Domain.Entities.PostTag>().Add(postTag);
        await _context.SaveChangesAsync(cancellationToken);

        return postTag.Id;
    }
}
