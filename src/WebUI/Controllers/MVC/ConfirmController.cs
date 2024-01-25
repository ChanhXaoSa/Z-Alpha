using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.CustomerAccount.Commands.CreateCustomerAccount;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
using ZAlpha.Domain.Identity;
using static Duende.IdentityServer.Models.IdentityResources;

namespace WebUI.Controllers.MVC;

public class ConfirmController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    private readonly IUserClaimsPrincipalFactory<UserAccount> _userClaimsPrincipalFactory;

    public ConfirmController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IUserClaimsPrincipalFactory<UserAccount> userClaimsPrincipalFactory)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public async Task<IActionResult> ExternalLoginCallback(string RedirectUrl, string remoteError = null)
    {
        RedirectUrl = RedirectUrl ?? Url.Content("~/");

        if (remoteError != null)
        {
            ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
            return LocalRedirect(RedirectUrl);
        }

        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            return LocalRedirect(RedirectUrl);
        }
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        // Kiểm tra xem người dùng đã đăng nhập hay chưa
        var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: true);

        if (signInResult.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(email);
            //tạo claim
            var check = await _userClaimsPrincipalFactory.CreateAsync(user) ?? throw new InvalidOperationException("Authenticated failed, please contact administrator!");
            await HttpContext.SignInAsync(check);
            return LocalRedirect(RedirectUrl);
        }
        else
        {
            if (signInResult.IsLockedOut)
            {
                return RedirectToAction("Index", "Login");
            }
            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);

                try
                {
                    var member = await Mediator.Send(new CreateCustomerAccountCommands { UserAccountId = user.Id });
                }
                catch (Exception ex)
                {
                    //tạo member
                    var tempMember = await Mediator.Send(new CreateCustomerAccountCommands { UserAccountId = user.Id});
                    //confirm email
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var result = await _userManager.ConfirmEmailAsync(user, code);
                }

                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: true);
                //tạo claim
                var check = await _userClaimsPrincipalFactory.CreateAsync(user) ?? throw new InvalidOperationException("Authenticated failed");

                await HttpContext.SignInAsync(check);
                return Redirect(RedirectUrl);
            }
        }
        return RedirectToAction("login", "auth");
    }
}
