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

        [HttpGet]
        [Route("{email:string}, {password:string}")]
        public async Task<User> Login(string email, string password)
        {
            User loginUser = new();
            List<User> userList = userrepoMongoDB.GetAll();
            loginUser = await Validate(e, p, userList);
            return loginUser;
        }

        [HttpPost]
        [Route("{user:User}")]
        public bool addUser(User user)
        {
            return userrepoMongoDB.AddUser(user);
        }

        protected async Task<User> Validate(string EmailAddress, string Password, List<User> list)
        {
            foreach (User u in list)
            {
                if (EmailAddress.ToLower().Equals(u.EmailAddress.ToLower()) && Password.Equals(u.Password))
                {
                    return u;
                }
            }
            return null;
        }

    }
}
