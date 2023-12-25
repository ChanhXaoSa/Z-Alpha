using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

public class LoginController : ControllerBaseMVC
{
    public IActionResult index() { return View(); }
}
