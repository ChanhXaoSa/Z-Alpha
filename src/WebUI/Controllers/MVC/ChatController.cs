using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class ChatController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Demo()
    {
        return View();
    }
}
