using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Comment.Queries.GetCommentById;
using ZAlpha.Application.Comment.Commands.CreateComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.InteractWithComments.Commands.CreateInteractWithComment;
using ZAlpha.Domain.Enums;

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
            var commentId = Mediator.Send(new CreateCommentCommands() { PostId = postId, Description = description }).Result;
            var interactWithCommentId = Mediator.Send(new CreateInteractWithCommentCommand() 
                    { UserAccountId = user.Id, CommentId = commentId, InteractCommentStatus= InteractCommentStatus.Create }).Result;

            TempData["Message"] = "Bạn đã đăng bình luận thành công";
        } else if (!User.Identity.IsAuthenticated && description != null)
        {
            return Redirect("~/Login");
        }
        var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
        var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = postId, Page = 1, Size = 100 });
        ViewBag.listComment = listComment;
        return View(post);
    }

   /* [HttpPost]
    public async Task<IActionResult> AddComment(string postId, string description)
    {
        if (User.Identity.IsAuthenticated && description != null)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var commentId = await Mediator.Send(new CreateCommentCommands() { UserAccountId = user.Id, PostId = Guid.Parse(postId), Description = description });
            var newComment = await Mediator.Send(new GetCommentByIdQueries() { Id = commentId });
            var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = Guid.Parse(postId), Page = 1, Size = 100 });
            //return PartialView("_CommentListPartial", listComment.Items);
            return Json(new { success = true, message = "Bạn đã đăng bình luận thành công", commentId = commentId, listComment });
        }
        else
        {
            return Json(new { success = false, message = "Đăng nhập để bình luận" });
        }
    }*/

    [HttpPost]
    public IActionResult YourAjaxMethod()
    {
        // Xử lý logic ở đây
        return Json(new { success = true, message = "Thành công!" });
    }
}
