using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class RecommendController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Recommend()
    {
        return View();
    }
}
