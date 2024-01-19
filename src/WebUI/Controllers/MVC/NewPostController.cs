using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistPost;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;

namespace WebUI.Controllers.MVC;
public class NewPostController : ControllerBaseMVC
{
	[HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> NewPost(Guid postId, string description, string postImgUrl)
    {
        try
        {
            //var postImgUrl = "postImgUrl";
            //var postTitle = "postTitle";
            //if (model == null) return Json("fail");
            //var postId = Mediator.Send(new CreatePsychologistPostCommand { PostDescription = model, PostImgUrl = postImgUrl, PostTitle = postTitle }).Result;
            //var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
            //return View("Index");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return View();
    }

    [HttpGet]
    public IActionResult NewPostPsychologist()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> NewPostPsychologist(string model, IFormFile file)
    {
        try
        {            
            var postImgUrl = "postImgUrl";
            var postTitle = "postTitle";
            if (model == null) return Json("fail");
            var postId = await Mediator.Send(new CreatePsychologistPostCommand{ PostDescription = model, PostImgUrl = postImgUrl, PostTitle = postTitle });
            var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
            return View("Views/Psychologist/Index.cshtml");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
