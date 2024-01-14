using CleanArchitecture.Application.Post.Queries.GetAllPost;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

public class HomeController : ControllerBaseMVC
{
    public IActionResult index() 
    {
        try
        {
            var result =  Mediator.Send(new GetPostQueries() { Page = 1, Size = 10 }).Result;
            return View(result);
            //return View();
        }
        catch (Exception ex)
        {
           throw new Exception(ex.Message);
        }

    }
}
