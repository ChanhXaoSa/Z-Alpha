using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

public class HomeController : ControllerBaseMVC
{
    public IActionResult index() { return View(); }
}
