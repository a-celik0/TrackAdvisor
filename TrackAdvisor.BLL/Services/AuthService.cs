using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.BLL.Services
{
    public class AuthService : IAuthService
    {
        // Now using IUserRepository instead of AppDbContext
        // This allows us to pass a fake repository during testing
        private readonly IUserRepository _userRepository;

        // Constructor — IUserRepository comes from outside (Dependency Injection)
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // User registration
        public bool Register(string email, string password)
        {
            // Check if email or password is empty
            if (email == null || email.Trim() == "" || password == null || password.Trim() == "")
            {
                return false;
            }

            // Check if a user with the same email already exists
            User existingUser = _userRepository.FindByEmail(email);
            if (existingUser != null)
            {
                return false;
            }

            // Create new user
            User newUser = new User();
            newUser.Email = email;
            newUser.Password = password;

            // Save user
            _userRepository.Save(newUser);

            return true;
        }

        public bool Login(string email, string password)
        {
            // Check if email or password is empty
            if (email == null || email.Trim() == "" || password == null || password.Trim() == "")
            {
                return false;
            }

            // Find user by email
            User user = _userRepository.FindByEmail(email);

            // Return false if user not found
            if (user == null)
            {
                return false;
            }

            // Check if password is correct
            return user.Password == password;
        }

        // Get user by email — used after login to read UserID and Role
        public User GetUserByEmail(string email)
        {
            return _userRepository.FindByEmail(email);
        }
    }
}