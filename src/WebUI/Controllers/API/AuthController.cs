using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers.API;
using WebUI.Model;

namespace WebUI.Controllers.Auth;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiControllerBase
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
        return BadRequest("Đăng ký thất bại!");
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        var result = await accountRepository.SignInAsync(model);
        if (string.IsNullOrEmpty(result))
        {
            return BadRequest("Sai tên đăng nhập hoặc mật khẩu!");
        }
        return Ok(result);
    }



}
