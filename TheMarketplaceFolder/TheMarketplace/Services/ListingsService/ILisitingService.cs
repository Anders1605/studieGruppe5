using Shared.Models;

namespace TheMarketplace.Services.ListingsService
{
    public interface ILisitingService
    {
        Task<Listing[]> GetAll();
        
        Task Add(Listing Listing);
        
        //Task DeleteById(int id);
    }
}
