using ZAlpha.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Identity;
using ZAlpha.Application.CustomerAccount.Commands.CreateCustomerAccount;
using ZAlpha.Application.PsychologistAccount.Commands.CreatePsychologistAccount;

namespace WebUI.Controllers.MVC;

public class RegisterController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;

    public RegisterController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpGet("register")]
    public IActionResult index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> index([FromForm] RegisterViewModel model, string radio)
    {
        try
        {
            var result = await _identityService.CreateNewUserAsync(model.Email, model.Username, model.FirstName, model.Lastname, model.Birthday, model.Address, model.Phone, model.Password);
            if (result.Result.Succeeded)
            {
                var user = await _identityService.GetUserAsync(result.UserId);
                if (radio.Equals("Customer"))
                {
                    var tempResult = await _userManager.AddToRoleAsync(user, "Customer");
                }
                else if (radio.Equals("Psychologist"))
                {
                    var tempResult = await _userManager.AddToRoleAsync(user, "Psychologist");
                }
                else
                {
                    return View(model);
                }
                if (radio.Equals("Customer"))
                {
                    var newCustomer = await Mediator.Send(new CreateCustomerAccountCommands
                    {
                        UserAccountId = user.Id
                    });
                    return Redirect("~/login");
                }
                else
                {
                    var newPsychologist = await Mediator.Send(new CreatePsychologistAccountCommands
                    {
                        UserAccountId = user.Id
                    });
                    return Redirect("~/login");
                }
            } else
            {
                return View(model);
            }
        }
        catch (Exception)
        {
            return View(model);
        }
        
    }
}
