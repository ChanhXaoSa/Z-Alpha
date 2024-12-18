﻿using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.InteractWithPost.Commands.CreateInteractWithPost;
using ZAlpha.Domain.Enums;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.WishListPost.Commands.CreateWishListPost;
using ZAlpha.Application.Post.Queries.GetPostBySearch;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;
using ZAlpha.Application.Tag.Queries.GetTag;
using ZAlpha.Application.Post.Commands.CreatePost;
using ZAlpha.Application.PostTag.Commands.CreatePostTag;
using Microsoft.AspNetCore.Identity;
using ZAlpha.Domain.Identity;
using Microsoft.AspNetCore.Http;
using ZAlpha.Infrastructure.Persistence;
using ZAlpha.Application.Post.Queries.GetPostByUserIdInMonthQuery;
using ZAlpha.Application.PackDetail.Queries.GetPackDetailByUserId;
using ZAlpha.Application.InteractWithComments.Queries.GetAllInteractWithComment;
using ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;
using ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPost;
using ZAlpha.Application.Comment.Queries.GetComment;
using ZAlpha.Application.Common.Models;
using System.Text.RegularExpressions;

namespace WebUI.Controllers.MVC;

[Authorize]
public class HomeController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly IToastNotification _notification;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ApplicationDbContext _applicationDbContext;

    public HomeController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IWebHostEnvironment hostingEnvironment, IToastNotification notification)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
        _hostingEnvironment = hostingEnvironment;
        _notification = notification;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string search, int reload, int index)
    {
        try
        {
            // Thống kê Zalpha
            // Tổng số post 1 tháng
            ViewBag.TotalPosts = Mediator.Send(new GetAllPostInMonthQueries()).Result.Count;
            // Tổng số user đăng kí mới 1 tháng
            int totalcus = Mediator.Send(new GetCustomerAccountCreateInOneMonthRequest()).Result.TotalCount;
            int totalpsy = Mediator.Send(new GetAllPsychologistAccountCreateInOneMonthRequest()).Result.TotalCount;
            ViewBag.TotalNewUsers = totalcus + totalpsy;
            // Tổng số bình luận trong 1 tháng
            ViewBag.TotalComments = Mediator.Send(new GetCommentRequestInOneMonth()).Result.TotalCount;
            // Tổng số lượt tương tác trong tháng
            ViewBag.TotalInteracts = Mediator.Send(new GetAllIInteractWithPostInOneMonthRequest()).Result.TotalCount;

            var listUser = _identityService.GetListUsersAsync();
          
            //Cách hiển thị thanh bên trái   -- set mặc định =1 --
            ViewBag.Index = 1;
            // data mặc định
            ViewBag.PopularUsers = listUser.Result.Take(10);

            if (index != 0 && (reload == 0 || reload == null))
            {
                return Json(new { success = true, message = "thành công" });
            }
            if (index != 0 && reload == 1)
            {
                ViewBag.Index = index;
                if(index == 2)
                {
                    ViewBag.PopularUsers = listUser.Result
                    .Where(u => u.CustomerAccounts != null && u.CustomerAccounts.Any())
                    .Select(u => new
                    {
                        User = u,
                        LatestCustomerAccount = u.CustomerAccounts.OrderByDescending(c => c.Created).FirstOrDefault()
                    })
                    .OrderByDescending(u => u.LatestCustomerAccount.Created)
                    .Select(u => u.User)
                    .Take(10);
                }
                if (index == 3)
                {
                    ViewBag.PopularUsers = listUser.Result
                    .Where(u => u.PsychologistAccounts != null && u.PsychologistAccounts.Any())
                    .Select(u => new
                    {
                        User = u,
                        LatestCustomerAccount = u.PsychologistAccounts.OrderByDescending(c => c.Created).FirstOrDefault()
                    })
                    .OrderByDescending(u => u.LatestCustomerAccount.Created)
                    .Select(u => u.User)
                    .Take(10);
                }
            }
            //Send data 
            List<EmotionalStatus> emotionalStatusList = Enum.GetValues(typeof(EmotionalStatus)).Cast<EmotionalStatus>().ToList();
            var tags = Mediator.Send(new GetAllTagQueries() { Page = 1, Size = 50 }).Result;
            ViewBag.tags = tags;
            ViewBag.emotionalStatusList = emotionalStatusList;
            if(search!=null && reload == 1)
            {
                var result = Mediator.Send(new GetPostBySearchQueries() { keySearch = search.Trim(), Page = 1, Size = 100 }).Result;
                ViewBag.result = result;
                return View();
            }
            if(search != null && (reload == 0 || reload == null))
            {
                var result = Mediator.Send(new GetPostBySearchQueries() { keySearch = search.Trim(), Page = 1, Size = 100 }).Result;
                ViewBag.result = result;
                _notification.AddSuccessToastMessage(message: "Tìm kiếm thành công");
                return Json(new { success = true, message = "Tìm kiếm thành công" });
            }
            else
            {
                var result = Mediator.Send(new GetPostQueries() { Page = 1, Size = 100 }).Result;
                ViewBag.result = result;
                return View();
            }
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
            }
            else
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

    [HttpPost]
    public async Task<IActionResult> NewPost(string postBody, EmotionalStatus emostatus, IFormFile file, string checkboxIds, int isAnomymous)
    {
        string postTitle = null;
        try
        {
            //Xét gói package đăng ký
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var pack = Mediator.Send(new GetPackDetailByUseridQuery() { Page = 1, Size = 100, UserId = user.Id }).Result;
            //Chưa đăng ký gói
            if (pack == null)
            {
                var postListOfUser = Mediator.Send(new GetPostByUserIdInMonthQuery() { Page = 1, Size = 100, UserId = user.Id }).Result;
                var countOfPost = postListOfUser.Items.Count();
                if (countOfPost >= 300) //giới hạn đăng bài
                {
                    _notification.AddWarningToastMessage("Bạn đã hết lượt đăng bài trong 30 ngày! Hãy đăng ký gói tài khoản để mở khóa chức năng");
                    return Json(new { success = false, message = "Bạn đã hết lượt đăng bài trong 30 ngày! Hãy đăng ký gói tài khoản để mở khóa chức năng" });
                }
            }
            //tính số ngày còn lại
            if (pack != null) 
            {
                int totalDay = 0;
                int distanceDay = 0;
                bool isPremium = false;
                foreach (var item in pack.Items)
                { 
                    if(item != null)
                    {
                        if(item.EndDay>DateTime.Now) isPremium =true;
                        if (item.Pack.PackName.Equals("Tháng"))
                        {
                            

                        }
                    }
                }
               /* _notification.AddWarningToastMessage("Gói tài khoản của bạn đã hết hạn. Vui lòng đăng ký");
                return Json(new { success = false, message = "Gói tài khoản của bạn đã hết hạn. Vui lòng đăng ký" });*/
               //tạm khóa
            }

            //check postBody
            if (postBody == null)
            {
                _notification.AddWarningToastMessage("Vui lòng điền nội dung bài đăng của bạn");
                return Json(new { success = false, message = "Vui lòng điền nội dung bài đăng của bạn" });
            }
            string postImgUrl = "";
            // check file co phai la img khong || co file hay ko
            if (file == null)
                postImgUrl = "";
            else if (!(IsImageFile(file) && file.Length > 0))
                return Json("not file Image");
            else
                postImgUrl = SaveFileImage(file);
            AnonymousStatus isAno = AnonymousStatus.UnActive;
            if (isAnomymous == 1) isAno = AnonymousStatus.Active;

            // tao postID
            var postId = Mediator.Send(new CreatePostCommands { PostDescription = postBody, PostImgUrl = postImgUrl, PostTitle = postTitle, emotionalStatus = emostatus, anonymousStatus = isAno }).Result;
            // get UserId
            var userId = await _identityService.GetUserByNameAsync(User.Identity.Name);
            // Tao interacId
            var interactId = await Mediator.Send(new CreateInteractWithPostCommand() { UserAccountId = userId.Id, PostId = postId, InteractPostStatus = InteractPostStatus.Create });

            if (checkboxIds != null)
            {
                var tagIds = checkboxIds.Split('_');
                tagIds = tagIds.SkipLast(1).ToArray();
                tagIds.ToList().ForEach(t => Guid.Parse(t));
                for (int i = 0; i < tagIds.Length; i++)
                {
                    var postTagId = await Mediator.Send(new CreatePostTagCommands() { postID = postId, TagID = Guid.Parse(tagIds[i]) });
                }
            }
            _notification.AddSuccessToastMessage("Đăng thành công");
            return Json(new { success = true, message = "Đăng thành công" });
        }
        catch (Exception ex)
        {
            _notification.AddWarningToastMessage("Đã có lỗi xảy ra");
            return Json(new { success = false, message = "Đã có lỗi xảy ra" });
            throw new Exception(ex.Message);
        }

    }
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordModel model)
    {
        bool checker = true;
        var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
        var isCorrectPassword = await _userManager.CheckPasswordAsync(user, model.OldPassword);
        if (!isCorrectPassword)
        {
            ViewBag.OldPasswordValidate = "*Mật khẩu không hợp lệ hoặc không đúng ( Mật khẩu lớn hơn 8 kí tự, chứa 1 chữ hoa, 1 chữ thường và 1 kí tự đặc biệt.)";
            checker = false;
        }
        
        if (!Regex.IsMatch(model.NewPassword, "^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()<>?|{}~:]).*$"))
        {
            ViewBag.NewPasswordValidate = "*Mật khẩu không hợp lệ ( Mật khẩu lớn hơn 8 kí tự, chứa 1 chữ hoa, 1 chữ thường và 1 kí tự đặc biệt.)";
            checker = false;
        }
        else if (!model.NewPassword.Equals(model.ConfirmPassword))
        {
            ViewBag.PasswordConfirmValidate = "*Mật khẩu xác nhận không khớp với mật khẩu đã nhập";
            checker = false;
        }
        else if (isCorrectPassword && model.NewPassword.Equals(model.OldPassword))
        {
            ViewBag.NewPasswordValidate = "Mật khẩu mới trùng với mật khẩu cũ";
            checker = false;
        }

        if (checker)
        {
            var result = await _identityService.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            return Redirect("~/Home");
        }

        return View();
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
