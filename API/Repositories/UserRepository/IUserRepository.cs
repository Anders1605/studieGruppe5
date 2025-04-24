using Shared.Models;

namespace API.Repositories.UserRepository

{
    public interface IUserRepository
    {
        Task <User> GetByEmailAddress(string emailAddress);
        //Task <User> CreateUser(User user);

    }
}
