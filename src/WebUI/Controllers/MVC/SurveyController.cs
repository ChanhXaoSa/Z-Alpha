using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class SurveyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
