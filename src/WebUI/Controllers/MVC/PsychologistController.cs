using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;
using ZAlpha.Application.WishListPost.Queries.GetWishListPost;
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

            // Save data of post
            if (user != null)
            {
                SetUpViewData(user);
            }            
            //
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
            var result = Mediator.Send(new GetAllInteractWithPostByUserIdQueries() {UserId = user.Id, Page = 1, Size = 100 }).Result;
            if (user != null)
            {
                SetUpViewData(user);
            }
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IActionResult Rating()
    {
        return View();
    }
    public IActionResult NewPost()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> PostSaved()
    {
        try
        {
            List<PostModel> postModels = new List<PostModel>();
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var result = Mediator.Send(new GetWishlistPostQueries() { UserId = user.Id, Page = 1, Size = 100 }).Result;
            if (user != null)
            {
                SetUpViewData(user);
            }
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void SetUpViewData(UserAccount user)
    {
        var interactPosts = Mediator.Send(new GetAllInteractWithPostByUserIdQueries() { UserId = user.Id /*"871a809a-b3fa-495b-9cc2-c5d738a866cf"*/, Page = 1, Size = 100 }).Result;
        var wishPosts = Mediator.Send(new GetWishlistPostQueries() { UserId = user.Id, Page = 1, Size = 100 }).Result;
        ViewData["psyInteractPostCount"] = interactPosts.TotalCount;
        ViewData["psyWishPostCount"] = wishPosts.TotalCount;
    }
}
