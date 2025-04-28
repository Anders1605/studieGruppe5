using Blazored.LocalStorage;
using Shared.Models;
using System.Net.Http.Json;

namespace TheMarketplace.Services.UserService
{
    public class UserServiceMongoDB : IUserService
    {
        private string serverUrl = "https://localhost:7107";

        private HttpClient _client;
        private ILocalStorageService LocalStorage { get; set; }

        public UserServiceMongoDB(ILocalStorageService localStorage,HttpClient client)
        {
            LocalStorage = localStorage;
            _client = client;
        }
        public async Task createUser(User newUser)
        {
            await _client.PostAsJsonAsync<User>($"{serverUrl}/api/user", newUser);
        }

        public bool LoggedInMockStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginMongoDB(string EmailAddress, string Password)
        {
            User userOnline = new();
            //Noget med https getAsync eller lignende hvor email og pw sendes til controller 
            userOnline = await _client.GetFromJsonAsync<User>($"{serverUrl}/api/user/{EmailAddress}/{Password}/"); 
            return userOnline;
        }

        public async Task<bool> CheckLogin()
        {
            User loggedInUser = new();
            loggedInUser = await LocalStorage.GetItemAsync<User>("User Signed In");
            if (loggedInUser == null)
                return false;
            else return true;
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
