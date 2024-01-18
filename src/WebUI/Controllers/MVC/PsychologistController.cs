using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;
using ZAlpha.Application.Post.Queries.GetAllPost;
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

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Info()
    {
        return View();
    }

    public IActionResult PsychologistComment()
    {
        return View();
    }

    public IActionResult PsychologistPost(string userAccountId)
    {
        try
        {
            var result = Mediator.Send(new GetAllInteractWithPostByUserIdQueries() { Page = 1, Size = 100 }).Result;
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
