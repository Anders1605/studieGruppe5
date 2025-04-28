using Shared.Models;

namespace API.Repositories.ListingsRepository
{
    public interface IListingsRepository
    {
        public List<Listing> GetAll();
        
        public Listing GetAllByUserId(int id);

        public bool AddListing (Listing listing);
    }
}