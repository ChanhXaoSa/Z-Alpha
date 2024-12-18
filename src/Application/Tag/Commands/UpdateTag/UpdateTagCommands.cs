﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Comment.Commands.UpdateComment;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.Tag.Commands.UpdateTag;
public class UpdateTagCommands : IRequest<string>
{
    public string Id { get; init; }
    public string? TagName { get; set; }
}

public class UpdateTagCommandsHandler : IRequestHandler<UpdateTagCommands, string>
{
    private readonly IApplicationDbContext _context;

    public UpdateTagCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UpdateTagCommands request, CancellationToken cancellationToken)
    {
        var tag = await _context.Get<Domain.Entities.Tag>()
            .FindAsync(request.Id, cancellationToken);

        if (tag == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Tag), request.Id);
        }
        else
        {
            // Update tag, nếu TagName bằng null thì giữ nguyên TagName cũ  
            tag.TagName = request.TagName == null ? tag.TagName : request.TagName;
            _context.Get<Domain.Entities.Tag>().Update(tag);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return tag.Id.ToString();
    }
}