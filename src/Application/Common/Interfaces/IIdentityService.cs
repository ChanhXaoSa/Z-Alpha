using ZAlpha.Application.Common.Models;
using ZAlpha.Domain.Identity;

namespace ZAlpha.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<(Result Result, string UserId)> CreateNewUserAsync(string email, string userName, string firstName, string lastName, DateTime birthday, string address, string phone, string password);

    Task<UserAccount> GetUserByEmailAsync(string email);

    Task<UserAccount> GetUserByNameAsync(string name);

    Task<Result> DeleteUserAsync(string userId);

    Task<UserAccount> GetUserAsync(string userId);
}
