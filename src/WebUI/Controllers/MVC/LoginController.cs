using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Domain.Identity;

namespace WebUI.Controllers.MVC;

[Authorize]
[Route("/Home")]
public class LoginController : ControllerBaseMVC
{
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;

    public LoginController(UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult index() { return View(); }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout([FromQuery] string redirectUrl)
    {
        // Clear the existing external cookie
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        if (!string.IsNullOrEmpty(redirectUrl))
        {
            return LocalRedirect("/Home");
        }

        return LocalRedirect(redirectUrl);
    }
}
