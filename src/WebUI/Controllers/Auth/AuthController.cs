using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Model;

namespace WebUI.Controllers.Auth;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IAccountRepository accountRepository;

    public AuthController (IAccountRepository iAccountRepository)
    {
        accountRepository = iAccountRepository;
    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        var result = await accountRepository.SignUpAsync(model);
        if(result.Succeeded)
        {
            return Ok(result.Succeeded);
        }
        return Unauthorized();
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        var result = await accountRepository.SignInAsync(model);
        if (string.IsNullOrEmpty(result))
        {
            return Unauthorized();
        }
        return Ok(result);
    }



}
