using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class SavePostController : ControllerBaseMVC
{
    public IActionResult SavedPost()
    {
        return View();
    }
}
