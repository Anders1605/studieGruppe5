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
        //Bruger en user som objekt og sender den til API som opretter i Users-collection i DB
        public async Task createUser(User newUser)
        {
            await _client.PostAsJsonAsync<User>($"{serverUrl}/api/user", newUser);
        }

        //userOnline oprettes og sættes sammen med den bruger som har emailaddress og pw i db. Returnerer herefter brugeren. 
        public async Task<User> LoginMongoDB(string EmailAddress, string Password)
        {
            User userOnline = new(); 
            userOnline = await _client.GetFromJsonAsync<User>($"{serverUrl}/api/user/{EmailAddress}/{Password}/"); 
            return userOnline;
        }

        //Brugeren fra localstorage sættes ind i loggedInUser. Hvis loggedInUser er null(tom) returneres false.
        public async Task<bool> CheckLogin()
        {
            User loggedInUser = new();
            loggedInUser = await LocalStorage.GetItemAsync<User>("User Signed In");
            if (loggedInUser == null)
                return false;
            else return true;
        }
        //----------------------------------------------------
        public bool LoggedInMockStatus()
        {
            throw new NotImplementedException();
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

        public async Task<User>? GetLoggedInUser()
        {
            User? loggedInUser = await LocalStorage.GetItemAsync<User>("User Signed In");
            return loggedInUser;
        }
    }
}
