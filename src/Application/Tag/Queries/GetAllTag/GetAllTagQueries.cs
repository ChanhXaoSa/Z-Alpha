using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZAlpha.Application.Common.Models;

namespace ZAlpha.Application.Tag.Queries.GetTag;
public class GetAllTagQueries : IRequest<PaginatedList<TagModel>>
{

}
