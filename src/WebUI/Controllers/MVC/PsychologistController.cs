using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;
using ZAlpha.Domain.Identity;

namespace WebUI.Controllers.MVC;
public class PsychologistController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;

    public PsychologistController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
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
            var result = Mediator.Send(new GetPsychologistAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IActionResult Info()
    {
        return View();
    }

    public IActionResult PsychologistComment()
    {
        return View();
    }

    public IActionResult PsychologistPost()
    {
        try
        {
            Guid userId = Guid.Parse(HttpContext.Session.GetString("userId"));
            var result = Mediator.Send(new GetAllInteractWithPostByUserIdQueries() {UserId = userId, Page = 1, Size = 100 }).Result;
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IActionResult PsychologistRating()
    {
        return View();
    }
}
