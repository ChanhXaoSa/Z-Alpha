using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Post.Commands.DeletePost;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Post.Commands.UpdatePost;
public class UpdatePostCommands : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string PostTitle { get; set; }
    public string PostDescription { get; set; }
    public string PostImgUrl { get; set; }
    public EmotionalStatus emotionalStatus { get; set; }
}
public class UpdatePostCommandsHandler : IRequestHandler<UpdatePostCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdatePostCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdatePostCommands request, CancellationToken cancellationToken)
    {
        var post = await _context.Get<Domain.Entities.Post>()
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (post == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Post), request.Id);
        }

        post.PostTitle = request.PostTitle;
        post.PostBody = request.PostDescription;
        post.PostImagesUrl = request.PostImgUrl;
        post.EmotionalStatus = request.emotionalStatus;

        await _context.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}