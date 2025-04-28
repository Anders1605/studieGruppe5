using API.Repositories.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [Route("api/user")]

    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userrepoMongoDB;

        public UserController(IUserRepository userrepoMongoDB)
        {
            this.userrepoMongoDB = userrepoMongoDB;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userrepoMongoDB.GetAll();
        }


    }
}
