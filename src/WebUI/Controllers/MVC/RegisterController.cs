using CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

public class RegisterController : ControllerBaseMVC
{
    public IActionResult index() { return View(); }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
    {
        return View(model);
    }
}
