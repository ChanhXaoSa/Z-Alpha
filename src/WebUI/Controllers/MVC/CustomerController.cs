using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;
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
    public async Task<IActionResult> Index()
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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
