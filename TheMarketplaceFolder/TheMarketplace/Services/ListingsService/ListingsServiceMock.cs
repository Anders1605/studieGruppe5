using Shared.Models;
using Blazored.LocalStorage;

namespace TheMarketplace.Services.ListingsService
{
    public class ListingsServiceMock : ILisitingService
    {
        private ILocalStorageService LocalStorage { get; set; }
        
        private List<Listing> Listings = new List<Listing>()
        {
            new Listing {Title = "Title1", Price = 12, Description = "Something", Category = "Category1", Status = "Tilgængelig"},
            new Listing {Title = "Title2", Price = 123, Description = "Something more", Category = "Category2", Status = "Reserveret"},
            new Listing {Title = "Title3", Price = 1234, Description = "More of something", Category = "Category3", Status = "Solgt"}

        };
        
        public ListingsServiceMock(ILocalStorageService localStorage)
        { 
            LocalStorage = localStorage;
        }
    
        public async Task<Listing[]> GetAll()
        {
            return Listings.ToArray();
        }

        public async Task Add(Listing listing)
        {
            int max = 0;
            if (Listings.Count > 0)
                max = Listings.Select(b => b.ListingId).Max();
            listing.ListingId = max + 1;
            Listings.Add(listing);
        }

        /*public async Task DeleteById(int id)
        {
            Listings.RemoveAll(listing => listing.ListingId == id);
        }*/
        
        
    } 
}