using Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace TheMarketplace.Services.OfferService
{
    public class OfferServiceMongoDB : IOfferService
    {
        HttpClient httpClient;
        string baseURI = "https://localhost:7107/api/Offer";

        public OfferServiceMongoDB(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AcceptOffer(Offer offerToAccept, int listingId)
        {
            await httpClient.PostAsJsonAsync<Offer>(baseURI +$"/AcceptOffer/{listingId}", offerToAccept);
        }

        public async Task<List<Listing>> GetAllListingsWithOffers(User userToFindOffersFor)
        {
            return await httpClient.GetFromJsonAsync<List<Listing>>($"{baseURI}/GetOffersForUser/{userToFindOffersFor.EmailAddress}");
        }

        public async Task SubmitOffer(Listing ListingToSubmitOfferTo, User userSubmittingOffer)
        {
            await httpClient.PutAsJsonAsync<Tuple<Listing, User>>(baseURI, new Tuple<Listing, User>(ListingToSubmitOfferTo, userSubmittingOffer));
        }
    }

   
}
