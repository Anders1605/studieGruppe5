using MongoDB.Driver;
using Shared.Models;

namespace API.Repositories.OfferRepository
{
    public class OfferRepositoryMongoDB : IOfferRepository
    {
        private IMongoCollection<Offer> _offersCollection;

        private IMongoCollection<Listing> _listingsCollection;

        public OfferRepositoryMongoDB()
        {

            IMongoClient _client;

            //atlas database setup
            var password = "MiniProject";
            var mongoUri = $"mongodb+srv://andersotte:{password}@miniproject.ytyyofp.mongodb.net/?retryWrites=true&w=majority&appName=Miniproject";

            try
            {
                _client = new MongoClient(mongoUri);
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

            _offersCollection = _client.GetDatabase(dbName)
               .GetCollection<Offer>(collectionName);

            _listingsCollection = _client.GetDatabase(dbName).GetCollection<Listing>("Listings");

        }

        
        /// <summary>
        /// Accepts an offer, requested by a user (seller)
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        public async Task AcceptOfferAsync(Offer offer)
        {
            var filterListing = Builders<Listing>.Filter.Eq(x => x.OfferEmbedded.OfferId, offer.OfferId);

            var filterOffer = Builders<Offer>.Filter.Eq(x => x.OfferId, offer.OfferId);


            var updateListing = Builders<Listing>.Update.Set(x => x.OfferEmbedded.OfferAccepted, true);

            var updateOffer = Builders<Offer>.Update.Set(x => x.OfferAccepted, true);

            await _listingsCollection.UpdateOneAsync(filterListing, updateListing);
            await _offersCollection.UpdateOneAsync(filterOffer, updateOffer);
        }

        /// <summary>
        /// Gets all the offers, for a requested listing.
        /// </summary>
        /// <param name="listingId"></param>
        /// <returns></returns>
        public async Task<List<Listing>> GetOffersForListingAsync(string listingId)
        {
            var filter = Builders<Listing>.Filter.Eq("ListingId", listingId);

            return await _listingsCollection.FindAsync(filter).Result.ToListAsync();
        }

        /// <summary>
        /// Fetches all the listings, which has offers for the requested user.
        /// </summary>
        /// <param name="userEmailAddress"></param>
        /// <returns></returns>
        public async Task<List<Listing>> GetListingsWithOffersForUserAsync(string userEmailAddress)
        {
            return _listingsCollection.AsQueryable()
                .Where(x => x.UserEmbedded.EmailAddress == userEmailAddress && (x.OfferEmbedded != null && x.OfferEmbedded.OfferAccepted!))
                .ToList();
        }

        /// <summary>
        /// Submits an offer for a listed item, from a user (buyer) who requested to send the offer
        /// </summary>
        /// <param name="listingToSubmitOfferTo"></param>
        /// <param name="userSubmittingOffer"></param>
        /// <returns></returns>
        public async Task SubmitOfferAsync(Listing listingToSubmitOfferTo, User userSubmittingOffer)
        {
            //Insert The Offer

            long nextId = await _offersCollection.CountDocumentsAsync(Builders<Offer>.Filter.Empty) + 1;

            Offer offer = new() { OfferId = Convert.ToInt32(nextId), Buyer = userSubmittingOffer, OfferAccepted = false };

            await _offersCollection.InsertOneAsync(offer);

            //Update The Listing

            var filterListing = Builders<Listing>.Filter.Eq(x => x.ListingId, listingToSubmitOfferTo.ListingId);

            var updateListing = Builders<Listing>.Update.Set(x => x.OfferEmbedded, offer);

            await _listingsCollection.UpdateOneAsync(filterListing, updateListing);
        }


    }
}
