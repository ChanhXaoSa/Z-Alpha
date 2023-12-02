using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Identity;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebUI.Model;

namespace CleanArchitecture.Infrastructure.Repositories;
public class AccountRepository : IAccountRepository
{
    private readonly IConfiguration configuration;
    private UserManager<ApplicationUser> userManager;
    private SignInManager<ApplicationUser> signInManager;

    public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IConfiguration configuration)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
    }
    public async Task<string> SignInAsync(SignInModel model)
    {
        var signInResult = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if(!signInResult.Succeeded)
        {
            throw new InvalidOperationException("Sai tên đăng nhập hoặc mật khẩu. Vui lòng thử lại!");
            return string.Empty;
        }
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, model.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecrectKey"]));
        var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                //expires: DateTime.Now.AddDays(1),
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
        //return token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        var user = new ApplicationUser
        {
            
            Email = model.Email,
            UserName = model.Email,

        };
        return await userManager.CreateAsync(user, model.Password);
    }
}
