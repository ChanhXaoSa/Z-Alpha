using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Comment.Queries.GetComment;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Post.Queries.GetPostById;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.Post.Queries.GetAllPost;

namespace ZAlpha.Application.Comment.Queries.GetCommentById;

public class GetCommentByPostIdQueries : IRequest<PaginatedList<CommentModel>>
{
    public Guid PostId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}

// IRequestHandler<request type, return type>
public class GetCommentByPostIdQueriesHandler : IRequestHandler<GetCommentByPostIdQueries, PaginatedList<CommentModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetCommentByPostIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CommentModel>> Handle(GetCommentByPostIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var listComment = _context.Get<Domain.Entities.Comment>()
            .Where(x => x.IsDeleted == false && x.PostId == request.PostId)
            .AsNoTracking();

        var map = _mapper.ProjectTo<CommentModel>(listComment);

        var page = await PaginatedList<CommentModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}