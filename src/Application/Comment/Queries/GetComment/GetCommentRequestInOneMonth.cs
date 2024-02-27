using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;

namespace ZAlpha.Application.Comment.Queries.GetComment;
public class GetCommentRequestInOneMonth : IRequest<PaginatedList<CommentModel>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}

public class GetCommentRequestInOneMonthHandler : IRequestHandler<GetCommentRequestInOneMonth, PaginatedList<CommentModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCommentRequestInOneMonthHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CommentModel>> Handle(GetCommentRequestInOneMonth request, CancellationToken cancellationToken)
    {
        var comment = _context.Get<Domain.Entities.Comment>()
            .Where(x => x.IsDeleted == false && x.Created >= DateTime.Now.AddMonths(-1)).AsNoTracking();

        var map = _mapper.ProjectTo<CommentModel>(comment);

        var page = await PaginatedList<CommentModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}
