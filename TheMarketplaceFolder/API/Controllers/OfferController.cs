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
        [Route("/GetOffersForUser")]
        public async Task<List<Listing>> GetOffersForUserAsync([FromBody] User user)
        {
            return await _offerRepository.GetListingsWithOffersForUserAsync(user);
        }

        [HttpGet]
        [Route("/GetOfferForListing")]
        public async Task<List<Listing>> GetOffersForListingAsync(Listing listing)
        {
            return await _offerRepository.GetOffersForListingAsync(listing);
        }

        [HttpPut]
        [Route("/SubmitOffer")]
        public async Task SubmitOffer(Listing listing, User user)
        {
            await _offerRepository.SubmitOfferAsync(listing, user);
        }

        [HttpPost]
        [Route("/AcceptOffer")]
        public async Task AcceptOffer(Offer offer)
        {
            await _offerRepository.AcceptOfferAsync(offer);
        }
    }
}
