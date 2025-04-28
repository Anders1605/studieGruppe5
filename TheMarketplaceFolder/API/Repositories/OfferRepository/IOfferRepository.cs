using Shared.Models;

namespace API.Repositories.OfferRepository
{
    public interface IOfferRepository
    {
        public Task AcceptOfferAsync(Offer offer);

        public Task SubmitOfferAsync(Listing listingToAddOfferTo, User user);

        public Task<List<Listing>> GetOffersForListingAsync(string listingId);

        public Task<List<Listing>> GetListingsWithOffersForUserAsync(string userEmailAddress);
    }
}
