using Shared.Models;

namespace TheMarketplace.Services.UserService
{
    public class UserServiceMongoDB : IUserService
    {
        public void createUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public bool LoggedInMockStatus()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginMongoDB(string EmailAddress, string Password)
        {
            throw new NotImplementedException();
            //Noget med https getAsyn eller lignende hvor email og pw sendes til controller 
        }

        public Task SetMockUsersAsync()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLoggedInMock(bool validation)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserService.Login(string EmailAddress, string Password, List<User> list)
        {
            throw new NotImplementedException();
        }
    }
}
