using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Identity;

namespace WebUI.Controllers.MVC;
public class CustomerController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;

    public CustomerController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult PostList()
    {
        return View();
    }
    public IActionResult PostSaved()
    {
        return View();
    }
    public IActionResult Payment()
    {
        return View();
    }
    public IActionResult NewPost()
    {
        return View();
    }
}
