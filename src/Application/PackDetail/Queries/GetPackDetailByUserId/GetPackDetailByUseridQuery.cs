﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZAlpha.Application.Common.Exceptions;
using ZAlpha.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZAlpha.Application.PackDetail.Queries.GetPackDetail;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.Post.Queries.GetAllPost;

namespace ZAlpha.Application.PackDetail.Queries.GetPackDetailByUserId;

public class GetPackDetailByUseridQuery : IRequest<PaginatedList<PackDetailsModel>>
{
    public string UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}

// IRequestHandler<request type, return type>
public class GetPackDetailByUseridQueryHandler : IRequestHandler<GetPackDetailByUseridQuery, PaginatedList<PackDetailsModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetPackDetailByUseridQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PackDetailsModel>> Handle(GetPackDetailByUseridQuery request, CancellationToken cancellationToken)
    {
        // get 
        var packDetail = _context.Get<Domain.Entities.PackDetail>()
            .Where(x => x.IsDeleted == false && x.UserAccountId.Equals(request.UserId))
            .Include(x => x.Pack)
            .OrderBy(x => x.Created)
            .AsNoTracking();
        

        var map = _mapper.ProjectTo<PackDetailsModel>(packDetail);

        var page = await PaginatedList<PackDetailsModel>
            .CreateAsync(map, request.Page, request.Size);

        return page;
    }
}