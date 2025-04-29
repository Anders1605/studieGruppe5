using System.Collections.Generic;
using System.Net.Mail;
using MongoDB.Driver;
using Shared.Models;

namespace API.Repositories.UserRepository
{
    public class UserRepositoryMongoDB:IUserRepository
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
            
            // Anvendt DB og collection
            var dbName = "Miniproject";
            var collectionName = "Users";

            userCollection = client.GetDatabase(dbName)
               .GetCollection<User>(collectionName);
        
        }

        //Bruger et tomt filter, søger efter brugerne i userCollection og returnerer en liste.
        public List<User> GetAll()
        {
            var noFilter = Builders<User>.Filter.Empty;
            return userCollection.Find(noFilter).ToList();
        }


        //Opretter en liste med alle brugere, sætter validation til true og sammenligner email fra user-parametren til at kigge listen igennem.
        //Hvis der findes en med samme email, sættes validation til false. Hvis ikke der findes en bruger med samme email oprettes et nyt document i userCollection.
        //Returnerer en bool alt efter "resultatet" af forsøget på at oprette en bruger.
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
    }
}
