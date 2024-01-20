using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Identity;
using ZAlpha.Infrastructure.Identity;

namespace WebUI.Controllers.MVC;
public class RouteController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;

    public RouteController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> NewPost()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);

            var isCustomer = await _identityService.IsInRoleAsync(user.Id, AppRole.Customer);
            if (isCustomer)
            {
                return RedirectToAction("NewPost", "Customer");
            }
            var isPsychologist = await _identityService.IsInRoleAsync(user.Id.ToString(), AppRole.Psychologist);
            if (isCustomer)
            {
                return RedirectToAction("NewPost", "Psychologist");
            }
        }
        return RedirectToAction("NewPost", "Psychologist");
        return RedirectToAction("Index", "Home");
    }
}
