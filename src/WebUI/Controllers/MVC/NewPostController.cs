﻿using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistPost;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;

namespace WebUI.Controllers.MVC;
public class NewPostController : ControllerBaseMVC
{
	[HttpGet]
    public IActionResult NewPost()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> NewPost(string feeling, string question, string title, string rate , IFormFile file)
    {
        try
        {
            string postImgUrl = "";
            JObject description = new JObject();
            description.Add("feeling", feeling);
            description.Add("question", question);
            description.Add("rate", rate);
            // check file co phai la img khong
            if (IsImageFile(file) && file.Length > 0)
            {
                 postImgUrl = ConvertIFormFileToBase64(file);
            } else
            {
                return Json("File is not Image");
            }            
            if (feeling == null || question == null || title == null) return Json("fail");
            var postId = Mediator.Send(new CreatePsychologistPostCommand { PostDescription = description.ToString(), PostImgUrl = postImgUrl, PostTitle = title }).Result;
            var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
            //return View("Index");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return View();
    }
    [HttpGet]
    public IActionResult NewPostPsychologist()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> NewPostPsychologist(string model, IFormFile file)
    {
        try
        {
            string postImgUrl = "";
            if (IsImageFile(file) && file.Length > 0)
            {
                postImgUrl = ConvertIFormFileToBase64(file);
            }
            else
            {
                return Json("File is not Image");
            }            
            var postTitle = "postTitle";
            if (model == null) return Json("fail");
            var postId = await Mediator.Send(new CreatePsychologistPostCommand{ PostDescription = model, PostImgUrl = postImgUrl, PostTitle = postTitle });
            var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
            //return View("Views/Psychologist/Index.cshtml");
            return Ok();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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
}
