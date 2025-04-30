using Shared.Models;
using TheMarketplace.Pages;

namespace TheMarketplace.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Login(string EmailAddress, string Password, List<User> list);
        Task<User> LoginMongoDB(string EmailAddress, string Password);
        Task SetMockUsersAsync();
        Task createUser(User newUser);
        bool UpdateLoggedInMock(bool validation);
        bool LoggedInMockStatus();
        Task<bool> CheckLogin();
        Task<User> GetLoggedInUser();
    }
}
