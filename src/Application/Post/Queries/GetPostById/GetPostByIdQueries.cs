using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Entities;

namespace ZAlpha.Application.Post.Queries.GetPostById;

public class GetPostByIdQueries : IRequest<GetAllPost.PostModel>
{
    public Guid Id { get; set; }

}


// IRequestHandler<request type, return type>
public class GetPostByIdQueriesHandler : IRequestHandler<GetPostByIdQueries, GetAllPost.PostModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetPostByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<GetAllPost.PostModel> Handle(GetPostByIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var Post = _context.Get<Domain.Entities.Post>()
            .Where(x => x.IsDeleted == false && x.Id.Equals(request.Id))
            .Include(o => o.PostTags)
            .ThenInclude(o => o.Tag)
            .Include(o => o.InteractWithPosts)
            .ThenInclude(o => o.UserAccount)
            .Include(o => o.WishListPosts)
            .ThenInclude(o => o.UserAccount)
            .AsNoTracking()
            .FirstOrDefault();
        if (Post == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Post), request.Id);
        }

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.Map<GetAllPost.PostModel>(Post);

        // Paginate data
        return Task.FromResult(map); //Task.CompletedTask;
    }
}