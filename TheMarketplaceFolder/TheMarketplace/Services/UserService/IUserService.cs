using Shared.Models;
using TheMarketplace.Components.Pages;

namespace TheMarketplace.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Login(string EmailAddress, string Password, bool status);
        void SetUserTest();
        void createUser(User newUser);

    }
}
