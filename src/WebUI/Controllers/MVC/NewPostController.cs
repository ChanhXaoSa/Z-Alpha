using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistPost;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;

namespace WebUI.Controllers.MVC;
public class NewPostController : ControllerBaseMVC
{
	[HttpGet]
    public IActionResult NewPost()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> NewPost(string feeling, string question, string title, string rate , IFormFile file)
    {
        try
        {            
            JObject description = new JObject();
            description.Add("feeling", feeling);
            description.Add("question", question);
            description.Add("rate", rate);

            string postImgUrl = ConvertIformfileToString(file);
            if (feeling == null || question == null || title == null) return Json("fail");
            var postId = Mediator.Send(new CreatePsychologistPostCommand { PostDescription = description.ToString(), PostImgUrl = postImgUrl, PostTitle = title }).Result;
            var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
            //return View("Index");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return View();
    }
    private string ConvertIformfileToString(IFormFile file)
    {
        var result = new StringBuilder();
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
            {
                result.AppendLine(reader.ReadLine());
            }
        }
        return result.ToString();
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
