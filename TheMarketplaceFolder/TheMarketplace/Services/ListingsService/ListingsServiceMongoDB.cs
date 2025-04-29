using Blazored.LocalStorage;
using Shared.Models;
using TheMarketplace.Services.ListingsService;
using System.Net.Http.Json;



namespace TheMarketplace.Services.ListingsService

{
    public class ListingsServiceMongoDB : ILisitingService
    {
        private string serverUrl = "https://localhost:7107";
 
        private HttpClient _client;
        
        public ListingsServiceMongoDB(HttpClient client)
        {
            _client = client;
        }
        public Task<Listing[]> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Listing Listing)
        {
            throw new NotImplementedException();
        }
    }
}
