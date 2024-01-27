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
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using NToastNotify;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.IdentityModel.Tokens;

namespace WebUI.Controllers.MVC;

//[Authorize]
//[Route("/Home")]
public class LoginController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    public readonly IWebHostEnvironment _environment;
    private readonly IToastNotification _toastNotification;

    public LoginController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IWebHostEnvironment environment, IToastNotification toastNotification)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
        _environment = environment;
        _toastNotification = toastNotification;
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
    public async Task<IActionResult> index([FromForm] RegisterViewModel model, string radio, [FromQuery] string redirectUrl)
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

                //send email with link
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                string callbackUrl = "";

                if (radio.Equals("Customer"))
                {
                    callbackUrl = Url.Action("register", "confirm", new { code, userId = user.Id, redirect = redirectUrl }, protocol : Request.Scheme);

                    var newCustomer = await Mediator.Send(new CreateCustomerAccountCommands
                    {
                        UserAccountId = user.Id
                    });
                }
                else
                {
                    var newPsychologist = await Mediator.Send(new CreatePsychologistAccountCommands
                    {
                        UserAccountId = user.Id
                    });
                }

                // Gửi email xác nhận
                EmailSender mail = new EmailSender(_environment);
                var temp = mail.SendEmailNoBccAsync(model.Email, "Email Xác Nhận Từ Hệ Thống Zalpha",
            "<div style=\"font-family: Helvetica, Arial, sans-serif\">\r\n    <div>Xin chào: " + model.Username +
            "</div>\r\n    <br>\r\n    <div>Chúng tôi đã nhận được yêu cầu đăng ký tài khoản Zalpha.</div>\r\n    <br>\r\n    <div>Đây là link xác thực của bạn: "
            + $" <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Link xác thực</a>" + ".</div>\r\n    <br>\r\n    <div>\r\n        Nếu không phải bạn vừa yêu cầu đăng ký tài khoản Zalpha, hoặc có một ai đó khác đang dùng email\r\n        của bạn để đăng ký vào tài khoản; bạn có thể bỏ qua bước xác thực email này.\r\n    </div>\r\n    <br>\r\n <br> ");
                if (temp == true)
                {
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        _toastNotification.AddSuccessToastMessage("Gửi Mail xác nhận thành công!");
                        return Redirect("~/login");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _toastNotification.AddSuccessToastMessage("Gửi Mail xác nhận thành công!");
                        return Redirect("~/login");
                    }
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Gửi Email Thất bại! Vui lòng kiểm tra lại địa chỉ email");
                    return Redirect("~/login");
                }
                // Kết thúc gửi email xác nhận  
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

    // Send Email
    private async Task<bool> SendEmailAsync(string toMail, string subject, string confirmLink)
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse("tuankietgg29@gmail.com"));
        email.To.Add(MailboxAddress.Parse(toMail));
        email.Subject = subject;

        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = confirmLink };
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("tuankietgg29@gmail.com", "pmnx ycmh xcsn itel");
        try
        {
            smtp.Send(email);
        }
        catch (SmtpCommandException ex)
        {
            return false;
        }
        smtp.Disconnect(true);
        return true;
    }

    // Forgot Password
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("forgotPassword")]
    public IActionResult ForgotPassword([FromQuery] string redirectUrl)
    {
        ViewBag.Title = "Quên mật khẩu - Zalpha";
        ViewBag.canonicalLink = Url.Action("forgotpassword", "login", new { redirectUrl }, protocol: Request.Scheme);
        ViewBag.metaDescription = "";
        ViewBag.metaKeywords = "Zalpha";
        ViewBag.imageOg = "wwwroot/assets/images/zalpha.png";

        ViewBag.activeMenu = 100;
        if (redirectUrl != null)
        {
            ViewBag.RedirectUrl = redirectUrl;
        }
        else
        {
            ViewBag.RedirectUrl = "~/";
        }
        if (User.Identity.IsAuthenticated)
        {
            _toastNotification.AddWarningToastMessage("Bạn đã đăng nhập vào tài khoản!");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }


    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpPost("forgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromQuery] string redirectUrl, string email)
    {
        ViewBag.Title = "Quên mật khẩu - Zalpha";
        ViewBag.canonicalLink = Url.Action("forgotpassword", "login", new { redirectUrl }, protocol: Request.Scheme);
        ViewBag.metaDescription = "";
        ViewBag.metaKeywords = "Zalpha";
        ViewBag.imageOg = "wwwroot/assets/images/zalpha.png";

        ViewBag.activeMenu = 100;

        if (string.IsNullOrEmpty(redirectUrl)) redirectUrl = "~/";
        ClaimsPrincipal? result;
        try
        {
            var tempUsername = await _identityService.GetUserByEmailAsync(email);
            UserAccount user = new UserAccount();
            if (tempUsername == null)
            {
                ViewBag.email = "Email " + email + " chưa được đăng ký!";
                return View();
            }
            else
            {
                user = await _identityService.GetUserByEmailAsync(email);
            }
            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                ViewBag.email = "Tài khoản email này đã bị khóa hoặc chưa kích hoạt trên Hệ Thống Zalpha. Vui lòng liên hệ với Quản trị viên Của Zalpha để được hỗ trợ!";
                return View();
            }
            else
            {
                string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var callbackUrl = Url.Action(
                        "resetPass",
                        "login",
                         new { code, userId = user.Id, redirectUrl = redirectUrl, email = email },
                        protocol: Request.Scheme);

                var temp = await SendEmailAsync(email, "Email Xác Nhận Đặt Lại Mật Khẩu Từ Hệ Thống Zalpha",
            "<div style=\"font-family: Helvetica, Arial, sans-serif\">\r\n    <div>Xin chào: " + user.FirstName +" "+ user.LastName + "</div>\r\n    <br>\r\n    <div>Chúng tôi đã nhận được yêu cầu ĐẶT LẠI MẬT KHẨU cho tài khoản để dùng cho hệ thống Zalpha.</div>\r\n    <br>\r\n    <div>Đây là link xác thực của bạn: " + $" <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Link xác thực</a>" + ".</div>\r\n    <br>\r\n    <div>\r\n        Nếu không phải bạn vừa yêu cầu ĐẶT LẠI MẬT KHẨU tài khoản Zalpha, hoặc có một ai đó khác đang dùng email\r\n        của bạn để yêu cầu ĐẶT LẠI MẬT KHẨU cho tài khoản; bạn có thể bỏ qua bước xác thực email này.\r\n    </div>\r\n    <br>\r\n    <div style=\"font-weight: bold\">\r\n        Xin cảm ơn, <br>\r\n        <div style=\"color: #FF630E;\">Hệ thống BSmart</div>\r\n    </div>\r\n</div>");
                _toastNotification.AddSuccessToastMessage("Gửi Email xác nhận thành công, Vui lòng truy cập Email để tiếp tục Đặt lại Mật Khẩu");
                return Redirect("/login");
            }
        }
        catch (Exception ex)
        {
            ViewBag.email = "Email " + email + " chưa được đăng ký!";
            return View();
        }
    }




    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("resetPass")]
    public async Task<IActionResult> ResetPass([FromQuery] string redirectUrl, string email, string code)
    {
        if (code.IsNullOrEmpty())
        {
            _toastNotification.AddWarningToastMessage("Không được copy đường dẫn khi reset mật khẩu!");
            return RedirectToAction("login", "login");
        }

        ViewBag.canonicalLink = Url.Action("resetpass", "login", new { redirectUrl, email, code }, protocol: Request.Scheme);
        ViewBag.metaDescription = "";
        ViewBag.metaKeywords = "Zalpha";
        ViewBag.email = email;
        ViewBag.token = code;
        ViewBag.imageOg = "wwwroot/assets/images/zalpha.png";
        var user = await _identityService.GetUserByEmailAsync(email);
        var purpose = UserManager<UserAccount>.ResetPasswordTokenPurpose;
        var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var opt = new IdentityOptions();
        if (!await _userManager.VerifyUserTokenAsync(user, opt.Tokens.PasswordResetTokenProvider, purpose, token).ConfigureAwait(false))
        {
            _toastNotification.AddWarningToastMessage("Link xác nhận không chính xác hoặc đã hết hạn!");
            return RedirectToAction("login", "login");
        }
        if (redirectUrl != null)
        {
            ViewBag.RedirectUrl = redirectUrl;
        }
        else
        {
            ViewBag.RedirectUrl = "~/";
        }
        if (User.Identity.IsAuthenticated)
        {
            _toastNotification.AddWarningToastMessage("Bạn đã đăng nhập vào tài khoản!");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }


    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpPost("resetPass")]
    public async Task<IActionResult> ResetPass([FromQuery] string redirectUrl, [FromForm] string newPass, string confirmPass, string? email, string? token)
    {

        ViewBag.Title = "Đặt lại mật khẩu - Zalpha";

        ViewBag.canonicalLink = Url.Action("resetpass", "login", new { redirectUrl }, protocol: Request.Scheme);
        ViewBag.metaDescription = "";
        ViewBag.metaKeywords = "Zalpha";
        ViewBag.imageOg = "wwwroot/assets/images/zalpha.png";

        ViewBag.activeMenu = 100;

        if (email == null || email.Equals("") || token == null || token.Equals(""))
        {
            _toastNotification.AddWarningToastMessage("Bạn không thể đặt lại mật khẩu! Vui lòng sử dụng link đã được gửi tới trong Email của bạn!");
            return RedirectToAction("Login", "login");
        }

        if (string.IsNullOrEmpty(redirectUrl)) redirectUrl = "~/";
        ClaimsPrincipal? result;
        try
        {
            if (newPass.Equals(confirmPass))
            {
                if (!Regex.IsMatch(newPass, "^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()<>?|{}~:]).*$"))
                {
                    ViewBag.email = email;
                    ViewBag.token = token;
                    ViewBag.RedirectUrl = redirectUrl;
                    ViewBag.error = "Mật khẩu phải bao gồm ít nhất 6 ký tự, 1 ký tự in hoa, 1 số, 1 ký tự đặc biệt và không chứa khoảng trắng!";
                    return View();
                }
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    _toastNotification.AddWarningToastMessage("Bạn không thể đặt lại mật khẩu! Vui lòng sử dụng link đã được gửi tới trong Email của bạn!");
                    return RedirectToAction("login", "login");
                }
                var temp = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                var resetPassResult = await _userManager.ResetPasswordAsync(user, temp, newPass);
                if (!resetPassResult.Succeeded)
                {
                    _toastNotification.AddWarningToastMessage("Link xác nhận không chính xác hoặc đã hết hạn! Vui lòng sử dụng link đã được gửi tới trong Email của bạn!");
                    return RedirectToAction("login", "login");
                }
                _toastNotification.AddSuccessToastMessage("Bạn đã đặt lại mật khẩu thành công!");
                return RedirectToAction("login", "login", new { RedirectUrl = redirectUrl });
            }
            else
            {
                ViewBag.email = email;
                ViewBag.token = token;
                ViewBag.RedirectUrl = redirectUrl;
                ViewBag.error = "Mật khẩu và mật khẩu xác nhận không trùng nhau!";
                return View();
            }
        }
        catch (Exception ex)
        {
            ViewBag.RedirectUrl = redirectUrl;
            ViewBag.error = ex.Message;
            return View();
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
