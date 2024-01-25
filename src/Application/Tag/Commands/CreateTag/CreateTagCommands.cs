using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Comment.Commands.CreateComment;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.Tag.Commands.CreateTag;
public class CreateTagCommands : IRequest<Guid>
{
    public string TagName { get; set; }
}

public class CreateTagCommandsHandler : IRequestHandler<CreateTagCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTagCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTagCommands request, CancellationToken cancellationToken)
    {
        var tag = new Domain.Entities.Tag()
        {
            TagName = request.TagName
        };
        _context.Get<Domain.Entities.Tag>().Add(tag);
        await _context.SaveChangesAsync(cancellationToken);
        return tag.Id;
    }
}