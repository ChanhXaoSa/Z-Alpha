using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Comment.Queries.GetComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Domain.Entities;

namespace ZAlpha.Application.Comment.Queries.GetCommentById;
public class GetCommentByIdQueries : IRequest<ZAlpha.Domain.Entities.Comment>
{
    public Guid Id { get; set; }
}

// IRequestHandler<request type, return type>
public class GetCommentByIdQueriesHandler : IRequestHandler<GetCommentByIdQueries, ZAlpha.Domain.Entities.Comment>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetCommentByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ZAlpha.Domain.Entities.Comment> Handle(GetCommentByIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var comment = _context.Get<Domain.Entities.Comment>()
            .FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

        return comment;
    }
}
