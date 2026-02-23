using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public class UserService : IUserService
    {
        private static readonly List<User> _users = new();

        public List<User> GetUsers()
        {
            return _users;
        }

        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User input)
        {
            input.Id = Guid.NewGuid();
            _users.Add(input);
            return input;
        }
    }
}