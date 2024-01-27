using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class UpgradeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
