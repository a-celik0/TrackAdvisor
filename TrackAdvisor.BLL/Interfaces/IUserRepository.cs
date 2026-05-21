using TrackAdvisor.MODELS;

namespace TrackAdvisor.BLL.Interfaces
{
    public interface IUserRepository
    {
        // Email ile kullanıcı bul
        User FindByEmail(string email);

        // Yeni kullanıcı kaydet
        bool Save(User user);
    }
}