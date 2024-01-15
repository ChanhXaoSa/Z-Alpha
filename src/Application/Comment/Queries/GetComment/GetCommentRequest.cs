using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZAlpha.Application.Comment.Queries.GetComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ZAlpha.Application.Comment.Queries.GetAllComment;
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
