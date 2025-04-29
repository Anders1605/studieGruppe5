using Shared.Models;

namespace API.Repositories.ListingsRepository
{
    public interface IListingsRepository
    {
        public List<Listing> GetAll();
        
        public List<Listing> GetAllByUserId();

        public bool AddListing (Listing listing);
    }
}