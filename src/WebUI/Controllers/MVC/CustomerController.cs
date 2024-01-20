using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Tag.Queries.GetTag;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;

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
    public async Task<IActionResult> PostList()
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var result = Mediator.Send(new GetAllInteractWithPostByUserIdQueries() { UserId = /*user.Id*/ "871a809a-b3fa-495b-9cc2-c5d738a866cf", Page = 1, Size = 100 }).Result;
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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
