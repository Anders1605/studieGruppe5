using MongoDB.Driver;
using Shared.Models;

namespace API.Repositories.OfferRepository
{
    public class OfferRepositoryMongoDB
    {
        private IMongoCollection<Offer> offersCollection;

        public OfferRepositoryMongoDB()
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
            var collectionName = "Offers";

            offersCollection = client.GetDatabase(dbName)
               .GetCollection<Offer>(collectionName);

        }
    }
}
