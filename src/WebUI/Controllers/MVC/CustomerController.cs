using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Tag.Queries.GetTag;
using ZAlpha.Domain.Enums;
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
        List<EmotionalStatus> emotionalStatusList = Enum.GetValues(typeof(EmotionalStatus)).Cast<EmotionalStatus>().ToList();


        var tags = Mediator.Send(new GetAllTagQueries() { Page = 1, Size = 50 }).Result;
        ViewBag.tags = tags;
        ViewBag.emotionalStatusList = emotionalStatusList;
        return View();
    }
}
