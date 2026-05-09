using System;
using System.Linq;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.BLL.Services
{
    public class AuthService
    {
        // Database ile iletişim kurmak için DbContext??
        private readonly AppDbContext _context;

        // Dependency Injection: DbContext dışarıdan alınır
        // "Bana bir AppDbContext ver" diyorsun

        //dependency inversion
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        // Kullanıcı kayıt işlemi
        public bool Register(string email, string password)
        {
            // Email veya password boş mu kontrol edilir
            if (email == null || email.Trim() == "" || password == null || password.Trim() == "")
            {
                return false;
            }

            // Aynı email ile daha önce kullanıcı var mı kontrol edilir
            User existingUser = _context.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return false;
            }

            // Yeni kullanıcı oluşturulur
            User newUser = new User();
            newUser.Email = email;
            newUser.Password = password;

            // Kullanıcı database'e eklenir
            _context.Users.Add(newUser);

            // Değişiklikler database'e kaydedilir
            _context.SaveChanges();

            // Kayıt başarılı
            return true;
        }

        public bool Login(string email, string password)
        {
            // Email veya password boş mu kontrol edilir
            if (email == null || email.Trim() == "" || password == null || password.Trim() == "")
            {
                return false;
            }
            // Veritabanında email ve password eşleşen kullanıcı var mı kontrol edilir
            User user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            // Eğer kullanıcı bulunursa login başarılı, bulunmazsa başarısız
            return user != null;
        }
    }
}