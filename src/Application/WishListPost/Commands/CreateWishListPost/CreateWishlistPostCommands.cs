using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Comment.Commands.CreateComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Entities;

namespace ZAlpha.Application.WishListPost.Commands.CreateWishListPost;
public class CreateWishlistPostCommands : IRequest<Guid>
{
    public string UserAccountId { get; set; }
    public Guid PostId { get; set; }
    public bool IsDeleted { get; set; }
}

public class CreateWishlistPostCommandsHandler : IRequestHandler<CreateWishlistPostCommands, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateWishlistPostCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateWishlistPostCommands request, CancellationToken cancellationToken)
    {
        var checker = await _context.Get<Domain.Entities.WishListPost>()
            .FirstOrDefaultAsync(w => w.UserAccountId == request.UserAccountId && w.PostId == request.PostId, cancellationToken);
        if (checker != null)
        {
            checker.IsDeleted = request.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return checker.Id;
        } else
        {
            var wishListPost = new Domain.Entities.WishListPost()
            {
                PostId = request.PostId,
                UserAccountId = request.UserAccountId
            };

            _context.Get<Domain.Entities.WishListPost>().Add(wishListPost);
            await _context.SaveChangesAsync(cancellationToken);

            return wishListPost.Id;
        }
    }
}
