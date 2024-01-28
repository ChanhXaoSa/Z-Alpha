using System;
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

namespace ZAlpha.Application.PackDetail.Queries.GetPackDetailByUserId;

public class GetPackDetailByUseridQuery : IRequest<PackDetailsModel>
{
    public string UserId { get; set; }

}


// IRequestHandler<request type, return type>
public class GetPackDetailByUseridQueryHandler : IRequestHandler<GetPackDetailByUseridQuery, PackDetailsModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    // DI
    public GetPackDetailByUseridQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<PackDetailsModel> Handle(GetPackDetailByUseridQuery request, CancellationToken cancellationToken)
    {
        // get 
        var packDetail = _context.Get<Domain.Entities.PackDetail>()
            .Where(x => x.IsDeleted == false && x.UserAccountId.Equals(request.UserId))
            .OrderByDescending(x => x.EndDay)
            .FirstOrDefault();

        //null thì thoi chứ trả throw về bên controller bắt lỗi sai
       /* if (packDetail == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.PackDetail), request.UserId);
        }*/

        // AsNoTracking to remove default tracking on entity framework
        var map = _mapper.Map<PackDetailsModel>(packDetail);

        // Paginate data
        return Task.FromResult(map); //Task.CompletedTask;
    }
}