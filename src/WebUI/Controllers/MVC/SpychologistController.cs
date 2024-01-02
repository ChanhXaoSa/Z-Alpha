using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class SpychologistController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Info()
    {
        return View();
    }
}
