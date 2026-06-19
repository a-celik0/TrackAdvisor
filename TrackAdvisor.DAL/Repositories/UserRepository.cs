using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.DAL.Repositories
{
    // Real repository — connected to the database
    // Implements IUserRepository contract
    public class UserRepository : IUserRepository
    {
        // Bridge to connect to the database
        private readonly AppDbContext _context;

        // Constructor — AppDbContext comes from outside (Dependency Injection)
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Find user by email
        // Returns User if found, null if not found
        public User FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        // Save new user to the database
        // Returns true if successful
        public bool Save(User user)
        {
            // Add user to the database
            _context.Users.Add(user);

            // Save changes
            _context.SaveChanges();

            return true;
        }
        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }
    }
}