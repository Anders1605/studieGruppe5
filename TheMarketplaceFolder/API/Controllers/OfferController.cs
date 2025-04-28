using API.Repositories.OfferRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        protected readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet]
        [Route("/GetOffersForUser/{userEmailAddress}")]
        public async Task<List<Listing>> GetOffersForUserAsync([FromRoute] string userEmailAddress)
        {
            return await _offerRepository.GetListingsWithOffersForUserAsync(userEmailAddress);
        }

        [HttpGet]
        [Route("/GetOfferForListing{listingId}")]
        public async Task<List<Listing>> GetOffersForListingAsync([FromRoute] string listingId)
        {
            return await _offerRepository.GetOffersForListingAsync(listingId);
        }

        [HttpPut]
        [Route("/SubmitOffer")]
        public async Task SubmitOffer([FromBody] Tuple<Listing, User> tuple)
        {
            await _offerRepository.SubmitOfferAsync(tuple.Item1, tuple.Item2);
        }

        [HttpPost]
        [Route("/AcceptOffer")]
        public async Task AcceptOffer(Offer offer)
        {
            await _offerRepository.AcceptOfferAsync(offer);
        }
    }
}
