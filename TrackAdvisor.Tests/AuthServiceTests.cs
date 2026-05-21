using Microsoft.EntityFrameworkCore;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.DAL.Data;
using Xunit;

namespace TrackAdvisor.Tests
{
    public class AuthServiceTests
    {
        // Her test için temiz ve ayrı bir veritabanı oluşturan metod
        // dbName = her testte farklı isim veriyoruz ki testler birbirini etkilemesin
        private AppDbContext CreateDb(string dbName)
        {
            // InMemory veritabanı ayarlarını oluştur
            // UseInMemoryDatabase = SQLite değil, RAM'de geçici veritabanı kullan
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            // Bu ayarlarla AppDbContext oluştur ve döndür
            return new AppDbContext(options);
        }

        // [Fact] = "Bu bir test metodudur, otomatik çalıştır" demek
        // Test 1: Geçerli email ve şifre ile kayıt başarılı mı?
        [Fact]
        public void Register_WithValidData_ReturnsTrue()
        {
            // Arrange — hazırlık
            // "Test1" adında temiz bir veritabanı oluştur
            var db = CreateDb("Test1");
            // AuthService'e bu veritabanını ver
            var service = new AuthService(db);

            // Act — Register metodunu çalıştır
            // "test@mail.com" ve "1234" ile kayıt olmayı dene
            bool sonuc = service.Register("test@mail.com", "1234");

            // Assert — sonucu kontrol et
            // true bekliyoruz çünkü geçerli email ve şifre verdik
            Assert.True(sonuc);
        }
    }
}