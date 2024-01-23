using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC.Admin;
public class AdminController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View("./AdminHome/Index");
    }

    public IActionResult index2()
    {
        return View("./AdminHome/index2");
    }
}
