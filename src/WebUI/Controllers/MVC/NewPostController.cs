using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class NewPostController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
