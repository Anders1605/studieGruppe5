using MongoDB.Driver;
using Shared.Models;

namespace API.Repositories.ListingsRepository
{
    public class LisitingsRepositoryMongoDB
    {
        private IMongoCollection<Listing> listingsCollection;

        public LisitingsRepositoryMongoDB()
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
            var collectionName = "Listings";

            listingsCollection = client.GetDatabase(dbName)
               .GetCollection<Listing>(collectionName);


            
        }
        /*
        public List<Listing> GetAll()
        {
            var noFilter = Builders<Listing>.Filter.Empty;
            return listingsCollection.Find(noFilter).ToList();
        }

        public Listing Add(Listing newList)
        {
            listingsCollection.InsertOne(newList);
            return newList;
        }
        */
        
    }
}
