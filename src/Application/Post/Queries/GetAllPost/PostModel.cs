﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAlpha.Application.Common.Mappings;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Application.Post.Queries.GetAllPost;
public class PostModel : IMapFrom<Domain.Entities.Post>
{
    public Guid Id { get; set; }
    public string PostTitle { get; set; }
    public string PostBody { get; set; }
    public string? PostImagesUrl { get; set; }
    public EmotionalStatus? EmotionalStatus { get; set; }
    public AnonymousStatus AnonymousStatus { get; set; }
    public DateTime Created { get; set; }
    public IList<InteractWithPosts>? InteractWithPosts { get; set; }
    public IList<Domain.Entities.WishListPost>? WishListPosts { get; set; }
    public IList<ZAlpha.Domain.Entities.PostTag>? PostTags { get; set; }
    public IList<ZAlpha.Domain.Entities.Comment>? Comments { get; set; }
}
