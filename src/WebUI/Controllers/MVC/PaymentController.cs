using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class PaymentController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View();
    }
}
