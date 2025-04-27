using Shared.Models;
using TheMarketplace.Pages;

namespace TheMarketplace.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Login(string EmailAddress, string Password, List<User> list);
        Task SetMockUsersAsync();
        void createUser(User newUser);
        bool UpdateLoggedInMock(bool validation);
        bool LoggedInMockStatus();
    }
}
