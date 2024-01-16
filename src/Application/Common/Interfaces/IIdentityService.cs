using ZAlpha.Application.Common.Models;

namespace ZAlpha.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<(Result Result, string UserId)> CreateNewUserAsync(string email, string userName, string firstName, string lastName, DateTime birthday, string address, string phone, string password);

    Task<Result> DeleteUserAsync(string userId);
}
