using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistPost;
public class CreatePsychologistPostCommand : IRequest<Guid>
{
    public Guid PostId { get; set; }
    public string PostTitle { get; set; }
    public string PostDescription { get; set; }
    public string PostImgUrl { get; set; }
}

public class CreatePsychologistPostCommandHandler : IRequestHandler<CreatePsychologistPostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePsychologistPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePsychologistPostCommand request, CancellationToken cancellationToken)
    {
        var post = new Domain.Entities.Post()
        {
            Id = request.PostId,
            PostTitle = request.PostTitle,
            PostBody = request.PostDescription,
            PostImagesUrl = request.PostImgUrl,
        };

        _context.Get<Domain.Entities.Post>().Add(post);
        await _context.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}
