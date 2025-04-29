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

        //Returnerer en liste med alle brugerne fra User-collection. 
        [HttpGet]
        public List<User> Get()
        {
            return userrepoMongoDB.GetAll();
        }

        /*Opretter en user og en list af users. Listen sættes lig med alle brugerne i User-collection. Validate bruger listen samt email og pw fra routen som parametre.
        Returnerer kun en user i loginUser hvis validate finder en bruger med samme email og pw.*/
        [HttpGet]
        [Route("{email}/{password}/")]
        public async Task<User> Login(string email, string password)
        {
            User loginUser = new();
            List<User> userList = userrepoMongoDB.GetAll();
            loginUser = await Validate(email, password, userList);
            return loginUser;
        }

        //Tager brugeren fra routen og sætter den lig med result og forsøger derefter at indsætte i User-collection med AddUser. Returnerer true eller false efter resultatet.
        [HttpPost]
        public ActionResult<bool> AddUser([FromBody] User user)
        {
            bool result = userrepoMongoDB.AddUser(user);
            return Ok(result);
        }

        //-----------------------------------------------
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
