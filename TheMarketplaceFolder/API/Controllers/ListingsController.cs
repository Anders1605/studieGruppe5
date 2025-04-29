using API.Repositories.ListingsRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [Route("api/listing")]
    
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private IListingsRepository listingRepoMongoDB;

        public ListingsController(IListingsRepository listingRepoMongoDB)
        {
            this.listingRepoMongoDB = listingRepoMongoDB;
        }

        [HttpGet]
        public IEnumerable<Listing> Get()
        {
            return listingRepoMongoDB.GetAll();
        }

        public IEnumerable<Listing> GetAllByUserId()
        {
            return listingRepoMongoDB.GetAllByUserId();
        }
    }
}