using Blazored.LocalStorage;
using Shared.Models;
using System.Net.Http.Json;



namespace TheMarketplace.Services.ListingsService

{
    public class ListingsServiceMongoDB /*: ILisitingService*/
    {
        
        private string serverUrl = "https://localhost:7107";
 
        private HttpClient _client;
        
        public ListingsServiceMongoDB(HttpClient client)
        {
            _client = client;
        }

        /*public async Task GetAll()
        {
        }*/
        
        public async Task GetAllByUserId()
        {
        }
        
        public async Task AddListing()
        {
        }

        //---------------------------------------------
        /*public Task<Listing[]> GetAll()
        {
            throw new NotImplementedException();
        }*/

        public Task<Listing> GetListingById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Add(Listing Listing)
        {
            throw new NotImplementedException();
        }
}
}
