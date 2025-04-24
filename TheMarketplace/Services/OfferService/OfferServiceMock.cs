using Shared.Models;

namespace TheMarketplace.Services.OfferService
{
    public class OfferServiceMock : IOfferService
    {

        public User MockBuyer { get; set; }

        public User MockSeller { get; set; }

        public List<Listing> MockListings { get; set; }

        public OfferServiceMock()
        {
            MockBuyer = new User()
            {
                Name = "Buyer",
                Address = "testAddress",
                EmailAddress = "TestBuyer@email.dk",
                Password = "testPassword",
                ProfilePictureUrl = "none",
                TelephoneNumber = "1234567890"
            };

            MockSeller = new User()
            {
                Name = "Seller",
                Address = "testAddress",
                EmailAddress = "TestSeller@email.dk",
                Password = "testPassword",
                ProfilePictureUrl = "none",
                TelephoneNumber = "0987654321"
            };

            Offer MockOffer1 = new Offer()
            {
                OfferId = 1,
                Buyer = MockBuyer,
            };

            MockListings = new List<Listing>()
            {
                new Listing()
                {
                    ListingId = 1,
                    Category ="test",
                    Description = "test",
                    Price = 10,
                    Status ="Testing",
                    Title = "test1",
                    UserEmbedded = MockSeller,
                    OfferEmbedded = MockOffer1
                },

                new Listing()
                {
                    ListingId = 2,
                    Category ="test",
                    Description = "test",
                    Price = 10,
                    Status ="Testing",
                    Title = "test2",
                    UserEmbedded = MockSeller,
                }
            };


        }

        public Task AcceptOffer(Offer offerToAccept)
        {
            MockListings.Where(x => x.OfferEmbedded.OfferId == offerToAccept.OfferId).Single().OfferEmbedded.OfferAccepted = true;
            return Task.CompletedTask;
        }

        public async Task<List<Listing>> GetAllListingsWithOffers(User userToFindOffersFor)
        {
            return await Task.FromResult(MockListings.FindAll(x => x.UserEmbedded.EmailAddress == userToFindOffersFor.EmailAddress && x.OfferEmbedded is not null));
        }

        public Task SubmitOffer(Listing listingToSubmitOfferTo,User userSubmittingOffer)
        {
            MockListings.Find(x => x == listingToSubmitOfferTo).OfferEmbedded = new Offer()
            {
                OfferId = 2,
                Buyer = userSubmittingOffer,
            };
            return Task.CompletedTask;
        }
    }
}
