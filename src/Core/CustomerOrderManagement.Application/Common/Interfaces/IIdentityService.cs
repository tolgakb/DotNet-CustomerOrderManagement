using CustomerOrderManagement.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> UserExists(string email);

        Task<Result> AddToRolesAsync(string userId, List<string> roles);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthenticateAsync(string username, string password);

        Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string email, string password);

        Task<(Result Result, string UserId)> CreateExternalUserAsync(string fullName, string userName, string email, string loginProvider, string providerKey, string providerName);

        Task<Result> DeleteUserAsync(string userId);

        Task<Result> UpdatePasswordAsync(string userId, string oldPassword, string newPassword);

        Task<Result> UpdateEmailAsync(string userId, string email);
    }
}
