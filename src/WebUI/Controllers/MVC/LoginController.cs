using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ZAlpha.Domain.Identity;
using ZAlpha.Application.Common.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Google;
using ZAlpha.Application.Common.Models;

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
            var user = await _identityService.GetUserByEmailAsync(Email);
            if (user == null)
            {
                var result = await _signInManager.PasswordSignInAsync(Email, Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            } else
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu, vui lòng kiểm tra lại!";
        return View();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpPost("login/{provider}")]
    public async Task<IActionResult> LoginExternal(string provider, string? ReturnUrl = null)
    {
        if (!User.Identity.IsAuthenticated)
        {
            switch (provider.ToLower())
            {
                case GoogleDefaults.AuthenticationScheme or "google":
                    {
                        LoginViewModel model = new LoginViewModel
                        {
                            ReturnUrl = ReturnUrl,
                            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                        };
                        return View(model);
                    }
            }

            throw new Exception($"Provider {provider} not support");
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
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
