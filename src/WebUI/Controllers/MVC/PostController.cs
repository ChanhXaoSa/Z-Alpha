using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class PostController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
