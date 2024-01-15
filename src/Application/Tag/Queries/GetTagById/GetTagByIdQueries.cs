using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Tag.Queries.GetTag;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Tag.Queries.GetTagById;


public class GetTagByIdQueries : IRequest<TagModel>
{
    public Guid Id { get; set; }

}

// IRequestHandler<request type, return type>
public class GetTagByIdQueriesHandler : IRequestHandler<GetTagByIdQueries, TagModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetTagByIdQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TagModel> Handle(GetTagByIdQueries request, CancellationToken cancellationToken)
    {
        // get categories
        var Tag = _context.Get<Domain.Entities.Tag>()     
            .Where(x => x.IsDeleted == false && x.Id.Equals(request.Id))
            .AsNoTracking().FirstOrDefault();
        if (Tag == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Tag), request.Id);
        }

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.Map<TagModel>(Tag);

        // Paginate data
        return Task.FromResult(map); //Task.CompletedTask;
    }
}