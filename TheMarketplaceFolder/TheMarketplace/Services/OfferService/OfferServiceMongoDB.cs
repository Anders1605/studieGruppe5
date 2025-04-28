using Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace TheMarketplace.Services.OfferService
{
    public class OfferServiceMongoDB : IOfferService
    {
        HttpClient httpClient;
        string baseURI = "http://localhost:5128/api/OfferController";
        public OfferServiceMongoDB(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task AcceptOffer(Offer offerToAccept)
        {
            await httpClient.PostAsJsonAsync<Offer>(baseURI, offerToAccept);
        }

        public async Task<List<Listing>> GetAllListingsWithOffers(User userToFindOffersFor)
        {
           await httpClient.GetAsync(baseURI/)
        }

        public Task SubmitOffer(Listing ListingToSubmitOfferTo, User userSubmittingOffer)
        {
            throw new NotImplementedException();
        }
    }

   
}
