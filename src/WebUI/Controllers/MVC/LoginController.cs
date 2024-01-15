using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Domain.Identity;
using CleanArchitecture.Application.Common.Interfaces;
using System.Security.Claims;

namespace WebUI.Controllers.MVC;

//[Authorize]
//[Route("/Home")]
public class LoginController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;

    public LoginController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("login")]
    public IActionResult index()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> index(string Email, string Password)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(Email, Password, false, false);
            var user = HttpContext.User;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        // Clear the existing external cookie
        await _signInManager.SignOutAsync();

        return LocalRedirect("/Home");
    }
}
