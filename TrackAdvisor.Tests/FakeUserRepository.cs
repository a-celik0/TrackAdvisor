using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.Tests
{
    // Fake repository — no database connection
    // Only stores users in a list in memory
    public class FakeUserRepository : IUserRepository
    {
        // In-memory list instead of database
        private List<User> _users = new List<User>();

        // Find user by email from the list
        public User FindByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        // Save user to the list
        public bool Save(User user)
        {
            _users.Add(user);
            return true;
        }
        public User FindById(int id)
        {
            return _users.FirstOrDefault(u => u.UserID == id);
        }
    }
}