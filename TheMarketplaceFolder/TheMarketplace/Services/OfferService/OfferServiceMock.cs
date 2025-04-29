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

            Offer MockOffer2 = new Offer()
            {
                OfferId = 2,
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
                    OfferEmbedded = new List<Offer>{
                    MockOffer1
                    }
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
                    OfferEmbedded = new List<Offer>{
                        MockOffer2
                    }
                },

                 new Listing()
                {
                    ListingId = 3,
                    Category ="test",
                    Description = "test",
                    Price = 100,
                    Status ="Testing",
                    Title = "test3",
                    UserEmbedded = MockSeller,
                }
            };


        }

        //Too many code changes for this to work right now.
        //public Task AcceptOffer(Offer offerToAccept)
        //{
        //    Console.WriteLine(offerToAccept.OfferId);
        //    MockListings.Where(x => x.OfferEmbedded.OfferId == offerToAccept.OfferId).First().OfferEmbedded.OfferAccepted = true;
        //    return Task.CompletedTask;
        //}

        public Task AcceptOffer(Offer offer, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Listing>> GetAllListingsWithOffers(User userToFindOffersFor)
        {
            return await Task.FromResult(MockListings.FindAll(x => x.UserEmbedded.EmailAddress == userToFindOffersFor.EmailAddress && x.OfferEmbedded is not null));
        }


        public Task SubmitOffer(Listing listingToSubmitOfferTo, User userSubmittingOffer)
        {
            MockListings.Find(x => x == listingToSubmitOfferTo).OfferEmbedded.Add(new Offer()
            {
                OfferId = 3,
                Buyer = userSubmittingOffer,
            });
            return Task.CompletedTask;
        }
    }
}
