using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAdvisor.MODELS.Interfaces
{
    public interface IAuthService
    {
        bool Register(string email, string password);
        bool Login(string email, string password);
        User GetUserById(int id);
        User GetUserByEmail(string email); //Get user by email to read UserID and Role
    }
}
