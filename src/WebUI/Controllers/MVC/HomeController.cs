using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

public class HomeController : ControllerBaseMVC
{
    public IActionResult index() 
    {
        try
        {
            var result =  Mediator.Send(new GetPostQueries() { Page = 1, Size = 100 }).Result;
            return View(result);
            //return View();
        }
        catch (Exception ex)
        {
           throw new Exception(ex.Message);
        }

    }
}
