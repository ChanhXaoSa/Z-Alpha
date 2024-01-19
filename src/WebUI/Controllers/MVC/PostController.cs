using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Comment.Queries.GetCommentById;
using ZAlpha.Application.Comment.Commands.CreateComment;
using ZAlpha.Application.Common.Interfaces;

namespace WebUI.Controllers.MVC;
public class PostController : ControllerBaseMVC
{

    /* public async Task<IActionResult> Index(Guid postID)
     {
         var post = await Mediator.Send(new GetPostByIdQueries() { Id = postID });
         var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = postID, Page = 1, Size = 100 });
         ViewBag.listComment = listComment;
         return View(post);
     }*/
    private readonly IIdentityService _identityService;

    public PostController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IActionResult> Index(string userAccountId, Guid postId, string description)
    {
        
        var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
        if (User.Identity.IsAuthenticated && description != null)
        {
            var commentId = Mediator.Send(new CreateCommentCommands() { UserAccountId = user.Id, PostId = postId, Description = description }).Result;
        } else if (!User.Identity.IsAuthenticated && description != null)
        {
            return Redirect("~/Login");
        }
        var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
        var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = postId, Page = 1, Size = 100 });
        ViewBag.listComment = listComment;
        return View(post);
    }
    [HttpPost]
    public  ActionResult Test(string postId)
    {
        return Json(new { success = true });
       
    }
}
