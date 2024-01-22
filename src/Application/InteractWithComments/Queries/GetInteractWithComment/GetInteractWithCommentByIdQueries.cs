using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Comment.Queries.GetCommentById;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.InteractWithComments.Queries.GetInteractWithComment;
public class GetInteractWithCommentByIdQueries : IRequest<ZAlpha.Domain.Entities.InteractWithComments>
{
    public Guid Id { get; set; }
}

// IRequestHandler<request type, return type>
public class GetInteractWithCommentByIdQueriesHandler : IRequestHandler<GetInteractWithCommentByIdQueries, ZAlpha.Domain.Entities.InteractWithComments>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetInteractWithCommentByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ZAlpha.Domain.Entities.InteractWithComments> Handle(GetInteractWithCommentByIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var interact = _context.Get<Domain.Entities.InteractWithComments>()
            .FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

        return interact;
    }
}
