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

        public User CreateUser(User request)
        {
        var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };
        return _userRepository.Add(user);
        }
    }
}