using Shared.Models;

namespace API.Repositories.UserRepository

{
    public interface IUserRepository 
    {
        public List<User> GetAll();

        public bool AddUser(User user);

    }
}
