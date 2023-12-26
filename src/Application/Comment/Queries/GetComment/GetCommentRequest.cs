using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Comment.Queries.GetComment;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.CustomerAccount.Queries.GetAllCustomerAccount;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Comment.Queries.GetAllComment;
public class GetCommentRequest : IRequest<PaginatedList<CommentModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, PaginatedList<CommentModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCommentRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CommentModel>> Handle(GetCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = _context.Get<Domain.Entities.Comment>()
            .Where(x => x.IsDeleted == false).AsNoTracking();

        var map = _mapper.ProjectTo<CommentModel>(comment);

        var page = await PaginatedList<CommentModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
