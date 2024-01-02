using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class NewPostController : ControllerBaseMVC
{
    public IActionResult NewPost()
    {
        return View();
    }
  
    public IActionResult NewPostPsychologist()
    {
        return View();
    }
}
