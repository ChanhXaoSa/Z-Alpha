using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class MyPostController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View();
    }
}
