using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class TransactionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Transaction()
    {
        return View();
    }
}
