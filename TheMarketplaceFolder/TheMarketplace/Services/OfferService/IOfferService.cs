using Shared.Models;

namespace TheMarketplace.Services.OfferService
{
    public interface IOfferService
    {
        public Task SubmitOffer(Listing ListingToSubmitOfferTo, User userSubmittingOffer);

        public Task AcceptOffer(Offer offerToAccept,int listingId);

        public Task<List<Listing>> GetAllListingsWithOffers(User userToFindOffersFor);
    }
}
