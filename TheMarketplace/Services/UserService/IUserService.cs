using Shared.Models;
using TheMarketplace.Components.Pages;

namespace TheMarketplace.Services.UserService
{
    public interface IUserService
    {
        Task<User> LoginAsync(string EmailAddress, string Password);

    }
}
