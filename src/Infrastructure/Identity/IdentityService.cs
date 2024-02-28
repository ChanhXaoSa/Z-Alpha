using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Duende.IdentityServer.Models.IdentityResources;

namespace ZAlpha.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<UserAccount> _userManager;
    private readonly IUserClaimsPrincipalFactory<UserAccount> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<UserAccount> userManager,
        IUserClaimsPrincipalFactory<UserAccount> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new UserAccount
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<(Result Result, string UserId)> CreateNewUserAsync(string email, string userName, string firstName, string lastName, DateTime birthday, string address, string phone, string password)
    {
        var user = new UserAccount
        {
            UserName = userName,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            BirthDay = birthday,
            Address = address,
            Phone = phone,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(UserAccount user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<UserAccount> GetUserAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user;
    }

    public async Task<UserAccount> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

        return user;
    }

    public async Task<UserAccount> GetUserByNameAsync(string name)
    {
        var user = await _userManager.Users
            .Include(u => u.InteractWithPosts)
            .Include(u => u.InteractWithComments)
            .Include(u => u.WishListPosts)
            .FirstOrDefaultAsync(u => u.UserName.Equals(name));

        return user;
    }

    public async Task<List<UserAccount>> GetListUsersAsync()
    {
        var users = await _userManager.Users
            .Include(u => u.InteractWithPosts)
            .Include(u => u.InteractWithComments)
            .Include(u => u.WishListPosts)
            .Include(u => u.CustomerAccounts)
            .Include(u => u.PsychologistAccounts)
            .AsNoTracking()
            .ToListAsync();

        var sortedUsers = users.OrderByDescending(u =>
            u.InteractWithPosts.Where(i => i.InteractPostStatus == Domain.Enums.InteractPostStatus.Create).Count() +
            u.InteractWithComments.Where(i => i.InteractCommentStatus == Domain.Enums.InteractCommentStatus.Create).Count()
        ).ToList();

        return sortedUsers;
        //return users;
    }
    public async Task<Result> ChangePasswordAsync(UserAccount userAccount, string oldPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(userAccount, oldPassword, newPassword);

        return result.ToApplicationResult();
    }
}
