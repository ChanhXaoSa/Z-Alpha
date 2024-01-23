susing ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.InteractWithPost.Commands.CreateInteractWithPost;
using ZAlpha.Domain.Enums;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.WishListPost.Commands.CreateWishListPost;
using ZAlpha.Application.Post.Queries.GetPostBySearch;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers.MVC;


public class HomeController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly IToastNotification _notification;

    public HomeController(IIdentityService identityService, IToastNotification notification)
    {
        _identityService = identityService;
        _notification = notification;
    }
    public IActionResult index() 
    {
        try
        {
            
            var result =  Mediator.Send(new GetPostQueries() { Page = 1, Size = 100 }).Result;
            return View(result);
            //return View();
        }
        catch (Exception ex)
        {
           throw new Exception(ex.Message);
        }
    }

    public IActionResult Search(string keySearch)
    {
        try
        {
            var result = Mediator.Send(new GetPostQueries() { Page = 1, Size = 100 }).Result;
            if (keySearch != null)
            {
                result = Mediator.Send(new GetPostBySearchQueries() { keySearch = keySearch.Trim(), Page = 1, Size = 100 }).Result;
            }
            return View("./Index", result);
        }
        catch (Exception ex)
        {   
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> WishListPost(string postId, bool isDeleted)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var wishlistPostId = await Mediator.Send(new CreateWishlistPostCommands() { PostId = Guid.Parse(postId), UserAccountId = user.Id, IsDeleted = isDeleted });
            if (isDeleted == true)
            {
                _notification.AddSuccessToastMessage(message: "Đã bỏ lưu bài viết này");
                return Json(new { success = true, message = "Đã bỏ lưu bài viết này", wishlistPostId = wishlistPostId });
            } else
            { 
                _notification.AddSuccessToastMessage(message: "Đã lưu bài viết này");
                return Json(new { success = true, message = "Đã lưu bài viết này", wishlistPostId = wishlistPostId });
            }
        }
        else
        {
            _notification.AddWarningToastMessage("Đăng nhập để lưu bài viết");
            return Json(new { success = false, message = "Đăng nhập để lưu bài viết" });
        }
    }
}
