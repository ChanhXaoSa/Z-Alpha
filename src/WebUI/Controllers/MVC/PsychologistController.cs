using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistById;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.PsychologistAccount.Commands.UpdatePsychologistAccountCommand;
using ZAlpha.Application.WishListPost.Queries.GetWishListPost;
using ZAlpha.Domain.Identity;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
using ZAlpha.Application.Post.Queries.GetPostByUserIdQuery;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using ZAlpha.Application.Post.Queries.GetPostWishListByUserIdQuery;
using ZAlpha.Application.Ban.UpdateAvatarUser;
using Microsoft.Extensions.Hosting.Internal;

namespace WebUI.Controllers.MVC;

[Authorize]
public class PsychologistController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public PsychologistController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IWebHostEnvironment hostingEnvironment)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
        _hostingEnvironment = hostingEnvironment;
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
    [HttpGet]
    public async Task<IActionResult> Index(string? userId)
    {
        try
        {

            if (userId == null)
            {
                var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
                var result = Mediator.Send(new GetPsychologistAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
                return View(result);
            }
            else
            {
                var result = Mediator.Send(new GetPsychologistAccountByUserIdQueries() { UserAccountId = userId }).Result;
                return View(result);
            }

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
            var postList = Mediator.Send(new GetPostByUserIdQuery() { UserId = user.Id, Page = 1, Size = 100 }).Result;
            var result = Mediator.Send(new GetPsychologistAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
            ViewBag.postList = postList;
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

    [HttpGet]
    public async Task<IActionResult> PostSaved()
    {
        try
        {
            List<PostModel> postModels = new List<PostModel>();
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            if (user != null)
            {
                SetUpViewData(user);
            }
            //var result = Mediator.Send(new GetWishlistPostQueries() { UserId = user.Id, Page = 1, Size = 100 }).Result;
            var result = Mediator.Send(new GetPsychologistAccountByUserIdQueries() { UserAccountId = user.Id }).Result;

            var postList = Mediator.Send(new GetPostWishListByUserIdQuery() { UserId = user.Id, Page = 1, Size = 100 }).Result;
            ViewBag.postList = postList;
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

    [HttpPost]
    public async Task<IActionResult> UpdatePsychologistAccount(Guid Id,string FirstName,
        string LastName, string Phone, string Address, DateTime BirthDay, string Specialize,
        string Workplace, string Position, string Milestones, string Intro)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Phone = Phone;
            user.Address = Address;
            user.BirthDay = BirthDay;
            var result = await _userManager.UpdateAsync(user);

            var account = Mediator.Send(new UpdatePsychologistAccountCommand()
            {
                Id = Id,
                UserAccountId = user.Id,
                Specialization = Specialize,
                Workplace = Workplace,
                Position = Position,
                Milestone = Milestones,
                Intro = Intro
            }).Result;

            if (result.Succeeded)
            {               
                return Redirect("~/Psychologist/Index");
            }
            else
            {
                return Redirect("~/Psychologist/Index");
            }
        }
        else
        {
            Json(new { success = false, message = "Bạn cần phải đăng nhập" });
            return Redirect("~/login");
        }
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAvatarProfile(IFormFile fileAvatar)
    {
        var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
        string avaImgUrl = "";
        if (fileAvatar == null)
            return Json("file is null");
        else if (!(IsImageFile(fileAvatar) && fileAvatar.Length > 0))
            return Json("not file Image");
        else
        {
            avaImgUrl = SaveFileImage(fileAvatar);
            var isUpdated = Mediator.Send(new UpdateAvatarUserCommands { Id = user.Id, AvatarUrl = avaImgUrl }).Result;
        }
        return Json("Success");
    }
    private bool IsImageFile(IFormFile file)
    {
        if (Path.GetExtension(file.FileName).ToLower() != ".jpg"
            && Path.GetExtension(file.FileName).ToLower() != ".png"
            && Path.GetExtension(file.FileName).ToLower() != ".gif"
            && Path.GetExtension(file.FileName).ToLower() != ".jpeg")
        {
            return false;
        }
        return true;
    }
    private string SaveFileImage(IFormFile file)
    {
        string fileUrl = "";
        var webRootPath = _hostingEnvironment.WebRootPath;
        var uploadsFolder = Path.Combine(webRootPath, "uploads");

        // Ensure the uploads folder exists, create if not
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        // Generate a unique file name (you might want to use a GUID or something similar)
        var uniqueFileName = $"{file.FileName}";

        // Combine the uploads folder with the unique file name to get the full file path
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Copy the file to the target location
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
            fileUrl = Path.Combine("uploads", file.FileName);
        }
        return fileUrl;
    }
}
