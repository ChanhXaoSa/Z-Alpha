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
using System.Text.RegularExpressions;
using ZAlpha.Application.CustomerAccount.Commands.CreateCustomerAccount;
using ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistAccount;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.Identity.Client;

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
    public IActionResult index([FromQuery] string redirectUrl)
    {
        if (redirectUrl != null)
        {

            ViewBag.RedirectUrl = redirectUrl;

        }
        else
        {
            ViewBag.RedirectUrl = "~/";
        }
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
    public async Task<IActionResult> index(string login_username, string login_password)
    {
        if (ModelState.IsValid)
        {
            var user = await _identityService.GetUserByEmailAsync(login_username);
            if (user == null)
            {
                var result = await _signInManager.PasswordSignInAsync(login_username, login_password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            } else
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, login_password, true, false);
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
    [HttpGet("login/{provider}")]
    public IActionResult ExternalLogin(string provider, [FromQuery] string redirectUrl)
    {
        if (!User.Identity.IsAuthenticated)
        {
            switch (provider.ToLower())
            {
                case GoogleDefaults.AuthenticationScheme or "google":
                    {
                        var returnUrl = Url.Action("ExternalLoginCallback", "Confirm", new { RedirectUrl = redirectUrl });
                        var props = _signInManager.ConfigureExternalAuthenticationProperties("Google", returnUrl);
                        return new ChallengeResult("Google", props);
                    }
                case FacebookDefaults.AuthenticationScheme or "facebook":
                    {
                        var returnUrl = Url.Action("ExternalLoginCallback", "Confirm", new { RedirectUrl = redirectUrl });
                        var propeties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", returnUrl);
                        return new ChallengeResult("Facebook", propeties);
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
    [HttpPost("register")]
    public async Task<IActionResult> index([FromForm] RegisterViewModel model, string radio)
    {
        try
        {
            bool checker = true;
            var userCheck = await _identityService.GetUserByEmailAsync(model.Email);
            if (userCheck != null)
            {
                ViewBag.EmailValidate = "Đã tồn tại tài khoản chứa email này, vui lòng kiểm tra lại";
                checker = false;
            }
            if (!Regex.IsMatch(model.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
            {
                ViewBag.EmailValidate = "Email không hợp lệ, vui lòng nhập lại";
                checker = false;
            }
            userCheck = await _identityService.GetUserByNameAsync(model.Username);
            if (userCheck != null)
            {
                ViewBag.UsernameValidate = "Tên tài khoản đã tồn tại, vui lòng thử tên khác";
                checker = false;
            }
            if (!Regex.IsMatch(model.Password, "^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()<>?|{}~:]).*$"))
            {
                ViewBag.PasswordValidate = "Mật khẩu không hợp lệ ( Mật khẩu lớn hơn 8 kí tự, chứa 1 chữ hoa, 1 chữ thường và 1 kí tự đặc biệt.";
                checker = false;
            }
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ViewBag.PasswordConfirmValidate = "Mật khẩu xác nhận không khớp với mật khẩu đã nhập";
                checker = false;
            }
            if (radio.Equals("Customer"))
            {
                ViewBag.RoleCheck = "Customer";
            }
            else if (radio.Equals("Psychologist"))
            {
                ViewBag.RoleCheck = "Psychologist";
            }

            if (checker == false)
            {
                throw new Exception();
            }
            var result = await _identityService.CreateNewUserAsync(model.Email, model.Username, model.FirstName, model.Lastname, model.Birthday, model.Address, model.Phone, model.Password);
            if (result.Result.Succeeded)
            {
                var user = await _identityService.GetUserAsync(result.UserId);
                if (radio.Equals("Customer"))
                {
                    var tempResult = await _userManager.AddToRoleAsync(user, "Customer");
                }
                else if (radio.Equals("Psychologist"))
                {
                    var tempResult = await _userManager.AddToRoleAsync(user, "Psychologist");
                }
                else
                {
                    ViewBag.RegisterValidate = "false";
                    return View(model);
                }
                if (radio.Equals("Customer"))
                {
                    var newCustomer = await Mediator.Send(new CreateCustomerAccountCommands
                    {
                        UserAccountId = user.Id
                    });
                    return Redirect("~/login");
                }
                else
                {
                    var newPsychologist = await Mediator.Send(new CreatePsychologistAccountCommands
                    {
                        UserAccountId = user.Id
                    });
                    return Redirect("~/login");
                }
            }
            else
            {
                ViewBag.RegisterValidate = "false";
                return View(model);
            }
        }
        catch (Exception)
        {
            ViewBag.RegisterValidate = "false";
            return View(model);
        }

    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        // Clear the existing external cookie
        await _signInManager.SignOutAsync();

        return LocalRedirect("/Login");
    }
}
