using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WebUI.Controllers.MVC;
public class RecommendController : ControllerBaseMVC
{
    //[Authorize(Roles = "Customer")]
    public IActionResult Index()
    {
        return View();
    }
}
