using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class PostController : ControllerBaseMVC
{

    public async Task<IActionResult> Index(Guid postID)
    {
        var result = await Mediator.Send(new GetPostByIdQueries() { Id = postID });
        return View(result);
    }
}
