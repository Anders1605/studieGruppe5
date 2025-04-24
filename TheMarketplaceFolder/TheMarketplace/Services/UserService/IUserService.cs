using Shared.Models;
using TheMarketplace.Pages;

namespace TheMarketplace.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Login(string EmailAddress, string Password, bool status, List<User> list);
        Task SetMockUsersAsync();
        void createUser(User newUser);

    }
}
