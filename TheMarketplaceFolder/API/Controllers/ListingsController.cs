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
        private IListingsRepository listingsRepositoryMongoDB;

        public ListingsController(IListingsRepository listingRepositoryMongoDB)
        {
            this.listingsRepositoryMongoDB = listingsRepositoryMongoDB;
        }

        [HttpGet]
        public IEnumerable<Listing> Get()
        {
            return listingsRepositoryMongoDB.GetAll();
        }

        public IEnumerable<Listing> GetAllByUserId()
        {
            return listingsRepositoryMongoDB.GetAllByUserId();
        }

        [HttpPost]
        public IActionResult AddListings([FromBody] Listing newList)
        {
            var success = listingsRepositoryMongoDB.AddListings(newList);
            if (success)
                return Ok(newList);
            else
                return StatusCode(500, "Could not add listing");
        }

    }
}