﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Identity;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
using ZAlpha.Application.PsychologistAccount.Queries.GetPsychologistAccountBySearch;
using ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;
using ZAlpha.Application.Common.Models;

namespace WebUI.Controllers.MVC;
public class RecommendController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    //[Authorize(Roles = "Customer")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var result = Mediator.Send(new GetAllPsychologistAccountQueries() { Page = 1, Size = 1000 }).Result;
            return View(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Search(string keySearch, int filter)
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);

            var result = Mediator.Send(new GetAllPsychologistAccountQueries() { filter = filter, Page = 1, Size = 1000 }).Result;
            if (keySearch != null)
            {
                result = Mediator.Send(new GetPsychologistAccountBySearchQueries() { KeySearch = keySearch, filter = filter, Page = 1, Size = 1000 }).Result;
            }else if(keySearch == null) 
            {
                result = Mediator.Send(new GetAllPsychologistAccountQueries() { filter = filter, Page = 1, Size = 1000 }).Result;
            }

            ViewBag.keySearch = keySearch;
            ViewBag.filter = filter;          

            return View("Index", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public RecommendController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

}
