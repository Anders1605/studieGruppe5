﻿using Shared.Models;
using Blazored.LocalStorage;
using System.Runtime.InteropServices;

namespace TheMarketplace.Services.UserService
{
    public class UserServiceMock : IUserService
    {
        private ILocalStorageService LocalStorage { get; set; }

        private List<User> users = new List<User>()
        {
        new User {Name="Test1", TelephoneNumber="11111111", Address="Testevej 1", EmailAddress="test1@mail.com", Password="Test1", ProfilePictureUrl="test/billede1.jpg"},
        new User {Name="Test2", TelephoneNumber="22222222", Address="Testevej 2", EmailAddress="test2@mail.com", Password="Test2", ProfilePictureUrl="test/billede2.jpg"},
        new User {Name="Test3", TelephoneNumber="33333333", Address="Testevej 3", EmailAddress="test3@mail.com", Password="Test3", ProfilePictureUrl="test/billede3.jpg"}
        };

        public void createUser (User newUser)
        {
            Console.WriteLine($"New user is as follows:Name: {newUser.Name} \n TelephoneNumber: {newUser.TelephoneNumber} \n Address: {newUser.Address} \n Emailaddress: {newUser.EmailAddress} \n Password: {newUser.Password} \n ProfilePictureUrl: {newUser.ProfilePictureUrl} \n ---");
            users.Add(newUser);
            Console.WriteLine("Updated list of users in localstorage is now: \n ---");
            foreach(var user in users)
            {
                Console.WriteLine($"Name: {user.Name} \n TelephoneNumber: {user.TelephoneNumber} \n Address: {user.Address} \n Emailaddress: {user.EmailAddress} \n Password: {user.Password} \n ProfilePictureUrl: {user.ProfilePictureUrl} \n ---");
            }
            SetUserTest();
            Console.WriteLine("Localstorage was updated");
        }

        public void SetUserTest()
        {
            LocalStorage.SetItemAsync<List<User>>("UsersInStorage", users);
            Console.WriteLine("Users for test was created in localstorage");
        }

        //Async som forberedelse tíl mongoDB.
        protected async Task<bool> Validate(string EmailAddress, string Password)
        {
            foreach (User u in users)

                if (EmailAddress.Equals(u.EmailAddress) && Password.Equals(u.Password))
                {
                    return true;
                } return false;
        }

        public async Task<bool> Login(string EmailAddress, string Password, bool status)
        {
           bool validation = await Validate(EmailAddress, Password);
           Console.WriteLine($"Validation was {validation} for user with {EmailAddress}");
           if (validation == true)
            {
                status = true;
                Console.WriteLine($"User with {EmailAddress} is now loginStatus {status}");
            }
           return status;
        }

    }
}
