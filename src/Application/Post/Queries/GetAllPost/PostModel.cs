using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Post.Queries.GetAllPost;
public class PostModel : IMapFrom<Domain.Entities.Post>
{
    public string PostTitle { get; set; }
    public string PostBody { get; set; }
    public string? PostImagesUrl { get; set; }
    public int? NumberOfLikes { get; set; }
    public int? NumberOfDisLikes { get; set; }
    public AnonymousStatus AnonymousStatus { get; set; }
    public DateTime Created { get; set; }
    public IList<InteractWithPosts>? InteractWithPosts { get; set; }
    public IList<CleanArchitecture.Domain.Entities.PostTag>? PostTags { get; set; }
}
