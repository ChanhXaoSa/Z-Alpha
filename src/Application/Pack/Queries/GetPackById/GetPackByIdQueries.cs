using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Comment.Queries.GetCommentById;
using ZAlpha.Application.Common.Interfaces;

namespace ZAlpha.Application.Pack.Queries.GetPackById;
public class GetPackByIdQueries : IRequest<ZAlpha.Domain.Entities.Pack>
{
    public Guid Id { get; set; }
}

// IRequestHandler<request type, return type>
public class GetPackByIdQueriesHandler : IRequestHandler<GetPackByIdQueries, ZAlpha.Domain.Entities.Pack>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetPackByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ZAlpha.Domain.Entities.Pack> Handle(GetPackByIdQueries request, CancellationToken cancellationToken)
    {
        // get 
        var pack = _context.Get<Domain.Entities.Pack>()
            .FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

        return pack;
    }
}
