using TrackAdvisor.MODELS;

namespace TrackAdvisor.MODELS.Interfaces
{
    public interface IUserRepository
    {
        // Find a user by email
        User FindByEmail(string email);

        // Save a new user to the database
        bool Save(User user);
    }
}