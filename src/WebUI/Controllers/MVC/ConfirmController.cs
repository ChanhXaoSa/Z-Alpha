using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NToastNotify;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Identity;
using System.Security.Claims;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;

namespace WebUI.Controllers.MVC;
public class ConfirmController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    private readonly IToastNotification _toastNotification;
    private readonly IUserClaimsPrincipalFactory<UserAccount> _userClaimsPrincipalFactory;

    public ConfirmController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IToastNotification toastNotification, IUserClaimsPrincipalFactory<UserAccount> userClaimsPrincipalFactory)
    {
        _identityService = identityService;
        this.userManager = userManager;
        _signInManager = signInManager;
        _toastNotification = toastNotification;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
    }
    public async Task<IActionResult> Index(string code, string userId, string redirect, string? introduce)
    {
        ViewBag.activeMenu = 100;
        if (userId == null || code == null)
        {
            _toastNotification.AddErrorToastMessage("Xác nhận Email không thành công, Link xác nhận không chính xác! Vui lòng sử dụng đúng link được gửi từ Hệ Thống Zalpha tới Email của bạn!");
            return Redirect("~/");
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            _toastNotification.AddErrorToastMessage("Xác nhận Email không thành công, Link xác nhận không chính xác! Vui lòng sử dụng đúng link được gửi từ Hệ Thống Zalpha tới Email của bạn!");
            return RedirectToAction("index", "login", new { redirectUrl = redirect });
        }

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await userManager.ConfirmEmailAsync(user, code);
        string StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
        if (result.Succeeded)
        {
            var tempUser = _identityService.GetUserAsync(userId).Result;
            var role = userManager.GetRolesAsync(tempUser).Result.FirstOrDefault();

            if (role.Equals("Customer"))
            {
                _toastNotification.AddSuccessToastMessage("Xác nhận email thành công, Vui lòng đăng nhập để truy cập vào tài khoản của bạn");
            }
            else if (role.Equals("Psychologist"))
            {
                _toastNotification.AddSuccessToastMessage("Xác nhận email thành công, Vui lòng đợi quản trị viên của Zalpha liên hệ để kích hoạt tài khoản.");
            }
        }
        else
        {
            _toastNotification.AddErrorToastMessage("Xác nhận Email không thành công, Link xác nhận không chính xác hoặc đã hết hạn! Vui lòng sử dụng đúng link được gửi từ Hệ Thống Zalpha tới Email của bạn!");
        }

        return RedirectToAction("index", "Login", new { redirectUrl = redirect });
    }


    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]

    public async Task<IActionResult> ExternalLoginCallback(string RedirectUrl, string remoteError = null)
    {
        // ViewBag.listCoursesSuggest = getListCourses();
        ViewBag.activeMenu = 100;
        RedirectUrl = RedirectUrl ?? Url.Content("~/");

        if (remoteError != null)
        {
            ModelState.AddModelError(string.Empty, $"Lỗi từ đăng nhập Google:{remoteError}");
            return LocalRedirect(RedirectUrl);



        }
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            ModelState.AddModelError(string.Empty, $"Lỗi từ lấy thông tin Google");

            return LocalRedirect(RedirectUrl);



        }

        var email = info.Principal.FindFirstValue(ClaimTypes.Email);

        var signIn = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
        if (signIn.Succeeded)
        {
            var user = await userManager.FindByEmailAsync(email);
            //tạo claim
            var check = await _userClaimsPrincipalFactory.CreateAsync(user) ?? throw new InvalidOperationException("Authenticated failed, please contact administrator!");

            // await HttpContext.SignInAsync(check);

            return LocalRedirect(RedirectUrl);

        }
        else
        {
            if (signIn.IsLockedOut)
            {
                _toastNotification.AddErrorToastMessage("Tài khoản của bạn đã bị khóa!");
                return RedirectToAction("login", "auth");
            }

            if (email != null)
            {
                var user = await userManager.FindByEmailAsync(email);

                try
                {
                    var member = await Mediator.Send(new GetCustomerAccountByUserIdQueries { UserAccountId = user.Id });
                }
                catch (Exception ex)
                {

                    //confirm email
                    string code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var result = await userManager.ConfirmEmailAsync(user, code);
                }

                await userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: false);
                //tạo claim
                var check = await _userClaimsPrincipalFactory.CreateAsync(user) ?? throw new InvalidOperationException("Authenticated failed, Vui lòng liên hệ quản trị viên của Zalpha để được xử lý!");

                // await HttpContext.SignInAsync(check);
                _toastNotification.AddSuccessToastMessage("Đăng nhập bằng Google thành công");
                return Redirect(RedirectUrl);
            }
        }
        _toastNotification.AddErrorToastMessage("Đăng nhập bằng Email không thành công");
        return RedirectToAction("login", "auth");
    }

    public async Task<IActionResult> ConfirmForgotPass(string code, string userId, string redirect)
    {
        // ViewBag.listCoursesSuggest = getListCourses();
        ViewBag.activeMenu = 100;
        if (userId == null || code == null || redirect == null)
        {
            _toastNotification.AddErrorToastMessage("Xác nhận Email không thành công, Link xác nhận không chính xác! Vui lòng sử dụng đúng link được gửi từ Hệ Thống Zalpha tới Email của bạn!");
            return RedirectToAction("index", "login", new { redirectUrl = redirect });

        }
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            _toastNotification.AddErrorToastMessage("Xác nhận Email không thành công, Link xác nhận không chính xác! Vui lòng sử dụng đúng link được gửi từ Hệ Thống Zalpha tới Email của bạn!");
            return RedirectToAction("index", "login", new { redirectUrl = redirect });
        }

        var temp = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await userManager.ConfirmEmailAsync(user, temp);
        if (result.Succeeded)
        {
            _toastNotification.AddSuccessToastMessage("Xác nhận email thành công, Vui lòng đặt lại mật khẩu cho tài khoản của bạn!");

            ViewBag.redirectUrl = redirect;
            return RedirectToAction("ResetPass", "Auth", new { redirectUrl = redirect, email = user.Email, token = code });
        }
        else
        {
            _toastNotification.AddErrorToastMessage("Xác nhận Email không thành công, Link xác nhận không chính xác! Vui lòng sử dụng đúng link được gửi từ Hệ Thống Zalpha tới Email của bạn!");
            return RedirectToAction("index", "login", new { redirectUrl = redirect });

        }
    }
}
