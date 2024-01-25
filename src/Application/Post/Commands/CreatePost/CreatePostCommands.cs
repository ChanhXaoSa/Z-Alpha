using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistPost;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Post.Commands.CreatePost;
public class CreatePostCommands : IRequest<Guid>
{
    public string? PostTitle { get; set; }
    public string PostDescription { get; set; }
    public string? PostImgUrl { get; set; }
    public EmotionalStatus? emotionalStatus { get; set; }
    public AnonymousStatus? anonymousStatus { get; set; }
    
}
public class CreatePostCommandsHandler : IRequestHandler<CreatePostCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePostCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePostCommands request, 
        CancellationToken cancellationToken)
    {
        var post = new Domain.Entities.Post()
        {
            PostTitle = request.PostTitle,
            PostBody = request.PostDescription,
            PostImagesUrl = request.PostImgUrl,
            EmotionalStatus = request.emotionalStatus,
            AnonymousStatus = request.anonymousStatus,
        };

        _context.Get<Domain.Entities.Post>().Add(post);
        await _context.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}
