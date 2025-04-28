using Shared.Models;

namespace API.Repositories.ListingsRepository
{
    public interface IListingsRepository
    {
        public List<Listing> GetAll();

        public bool AddListing (Listing listing);
    }
}