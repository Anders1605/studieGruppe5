using System.Collections.Generic;
using System.Net.Mail;
using MongoDB.Driver;
using Shared.Models;

namespace API.Repositories.UserRepository
{
    public class UserRepositoryMongoDB
    {
        private IMongoCollection<User> userCollection;

        public UserRepositoryMongoDB()
        {
            
            IMongoClient client;

            //atlas database setup
            var password = "MiniProject";
            var mongoUri = $"mongodb+srv://andersotte:{password}@miniproject.ytyyofp.mongodb.net/?retryWrites=true&w=majority&appName=Miniproject";

            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                throw;
            }
            
            // Set the name of the collection you want to use.
            var dbName = "Miniproject";
            var collectionName = "Users";

            userCollection = client.GetDatabase(dbName)
               .GetCollection<User>(collectionName);
        
        }

        public List<User> GetAll()
        {
            var noFilter = Builders<User>.Filter.Empty;
            return userCollection.Find(noFilter).ToList();
        }


        public bool AddUser(User user)
        {
            var compareList = GetAll();
            bool validation = true;
            foreach (User u in compareList)
            {
                if (user.EmailAddress.ToLower().Equals(u.EmailAddress.ToLower()))
                {
                    validation = false;
                }
            }
            if (validation)
            {
                userCollection.InsertOne(user);
            } 
            return validation;
        }

        public Task<bool> Login(string EmailAddress, string Password, List<User> list)


    }
}
