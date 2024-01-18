using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Comment.Queries.GetCommentById;
using ZAlpha.Application.Comment.Commands.CreateComment;

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


    public async Task<IActionResult> Index(string userAccountId, Guid postId, string description)
    {
        if (userAccountId != null && description != null)
        {
            var commentId = Mediator.Send(new CreateCommentCommands() { UserAccountId = userAccountId, PostId = postId, Description = description }).Result;
        }

        var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
        var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = postId, Page = 1, Size = 100 });
        ViewBag.listComment = listComment;
        return View(post);
    }
}
