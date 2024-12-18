﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
using ZAlpha.Application.Tag.Queries.GetTag;
using ZAlpha.Domain.Enums;
using ZAlpha.Domain.Identity;
using ZAlpha.Application.InteractWithPost.Queries.GetAllInteractWithPostByUserId;
using Newtonsoft.Json.Linq;
using ZAlpha.Application.Post.Commands.CreatePost;
using ZAlpha.Application.InteractWithPost.Commands.CreateInteractWithPost;
using ZAlpha.Application.PostTag.Commands.CreatePostTag;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Domain.Entities;
using ZAlpha.Application.WishListPost.Queries.GetWishListPost;
using ZAlpha.Application.Comment.Commands.CreateComment;
using ZAlpha.Application.InteractWithComments.Commands.CreateInteractWithComment;
using System.ComponentModel.Design;
using ZAlpha.Application.Post.Queries.GetPostByUserIdQuery;
using ZAlpha.Application.Post.Queries.GetPostWishListByUserIdQuery;
using ZAlpha.Application.Transaction.Queries.GetTransactionById;
using Microsoft.AspNetCore.Authorization;
using ZAlpha.Application.Ban.UpdateAvatarUser;
using ZAlpha.Application.Common.Models;

namespace WebUI.Controllers.MVC;


[Authorize]
public class CustomerController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public CustomerController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IWebHostEnvironment hostingEnvironment)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
        _hostingEnvironment = hostingEnvironment;
    }

    // Get Customer Info
    public async Task<IActionResult> Index()
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;

            //
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

    // Get Customer Info with route
    [HttpGet]
    public async Task<IActionResult> Index(string? userId)
    {
        try
        {

            if(userId == null)
            {
                var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
                var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
                return View(result);
            }
            else
            {
                var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = userId }).Result;
                return View(result);
            }
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // Update Customer Info
    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(string FirstName, string LastName, string Phone, string Address, DateTime BirthDay)
    {
        try
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
                if (result.Succeeded)
                {
                    Json(new { success = true, message = "Bạn đã chỉnh sửa thành công" });
                    return Redirect("~/Customer/Index");
                }
                else
                {
                    Json(new { success = false, message = "Chỉnh sửa thất bại" });
                    return Redirect("~/Customer/Index");
                }
            }
            else
            {
                Json(new { success = false, message = "Bạn cần phải đăng nhập" });
                return Redirect("~/Login");
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Chỉnh sửa thất bại!" });
        }
    }

    // Get Post List By Customer
    public async Task<IActionResult> PostList()
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var postList = Mediator.Send(new GetPostByUserIdQuery() { UserId = user.Id , Page = 1, Size = 100 }).Result;
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
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

    // Get Post save by Customer
    [HttpGet]
    public async Task<IActionResult> PostSaved()
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var postList = Mediator.Send(new GetPostWishListByUserIdQuery() { UserId = user.Id, Page = 1, Size = 100 }).Result;
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
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


    public IActionResult Payment()
    {
        return View();
    }
    [HttpGet]
    public IActionResult NewPost()
    {
        List<EmotionalStatus> emotionalStatusList = Enum.GetValues(typeof(EmotionalStatus)).Cast<EmotionalStatus>().ToList();

        var tags = Mediator.Send(new GetAllTagQueries() { Page = 1, Size = 50 }).Result;
        ViewBag.tags = tags;
        ViewBag.emotionalStatusList = emotionalStatusList;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> NewPost(string postbody, EmotionalStatus emostatus, IFormFile file, IFormCollection formCollection)
    {
        try
        {
            //test data 
            List<EmotionalStatus> emotionalStatusList = Enum.GetValues(typeof(EmotionalStatus)).Cast<EmotionalStatus>().ToList();
            var tags = Mediator.Send(new GetAllTagQueries() { Page = 1, Size = 50 }).Result;
            ViewBag.tags = tags;
            ViewBag.emotionalStatusList = emotionalStatusList;
            //
            if (postbody == null) return Json("fail;");
            string postImgUrl = "";
            //// check file co phai la img khong || co file hay ko
            if (file == null)
                postImgUrl = "";
            else if (!(IsImageFile(file) && file.Length > 0))
                return Json("not file Image");
            else
                postImgUrl = SaveFileImage(file);
            // tao postID
            var postId = Mediator.Send(new CreatePostCommands { PostDescription = postbody, PostImgUrl = postImgUrl, emotionalStatus = emostatus }).Result;
            // get UserId
            var userId = await _identityService.GetUserByNameAsync(User.Identity.Name);
            // Tao interacId
            var interactId = await Mediator.Send(new CreateInteractWithPostCommand() { UserAccountId = userId.Id, PostId = postId, InteractPostStatus = InteractPostStatus.Create });

            List<string> selectedValues = formCollection["SelectedValues"].ToList();
            foreach (var item in selectedValues)
            {
                Guid tagId = Guid.Parse(item);
                var postTagId = await Mediator.Send(new CreatePostTagCommands() { postID = postId, TagID = tagId });
            }
            //return View("Index");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return View("/");
    }
    public string ConvertIFormFileToBase64(IFormFile file)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();
            return Convert.ToBase64String(fileBytes);
        }
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

    private void SetUpViewData(UserAccount user)
    {
        var interactPosts = Mediator.Send(new GetAllInteractWithPostByUserIdQueries() { UserId = user.Id /*"871a809a-b3fa-495b-9cc2-c5d738a866cf"*/, Page = 1, Size = 100 }).Result;
        var wishPosts = Mediator.Send(new GetWishlistPostQueries() { UserId = user.Id, Page = 1, Size = 100 }).Result;
        ViewData["cusInteractPostCount"] = interactPosts.TotalCount;
        ViewData["cusWishPostCount"] = wishPosts.TotalCount;
    }
    [HttpGet]
    public async Task<IActionResult> EditInfo(string FirstName, string LastName, string Email, string Phone, string Address, DateTime BirthDay)
    {
        try
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Email = Email;
                user.Phone = Phone;
                user.Address = Address;
                user.BirthDay = BirthDay;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Json(new { success = true, message = "Bạn đã chỉnh sửa thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Chỉnh sửa thất bại" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Bạn cần phải đăng nhập" });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Chỉnh sửa thất bại!" });
        }
    }

    public async Task<IActionResult> Transaction()
    {
        try
        { 
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var transactionList = Mediator.Send(new GetTransactionByIdQueries() { UserId = user.Id, Page = 1, Size = 100 }).Result;
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;

            ViewBag.transactionList = transactionList;
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
}