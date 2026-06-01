using TrackAdvisor.BLL.Services;
using Xunit;

namespace TrackAdvisor.Tests
{
    public class AuthServiceTests
    {
        // Test 1: Valid email and password — should return true
        [Fact]
        public void Register_WithValidData_ReturnsTrue()
        {
            // Arrange — hazırlık
            var fakeRepo = new FakeUserRepository();
            var service = new AuthService(fakeRepo);

            // Act — çalıştır
            bool result = service.Register("test@mail.com", "1234");

            // Assert — kontrol et
            Assert.True(result);
        }

        // Test 2: Existing email — should return false
        [Fact]
        public void Register_WithExistingEmail_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeUserRepository();
            var service = new AuthService(fakeRepo);
            service.Register("test@mail.com", "1234");

            // Act
            bool result = service.Register("test@mail.com", "5678");

            // Assert
            Assert.False(result);
        }

        // Test 3: Valid credentials — should return true
        [Fact]
        public void Login_WithValidCredentials_ReturnsTrue()
        {
            // Arrange
            var fakeRepo = new FakeUserRepository();
            var service = new AuthService(fakeRepo);
            service.Register("test@mail.com", "1234");

            // Act
            bool result = service.Login("test@mail.com", "1234");

            // Assert
            Assert.True(result);
        }

        // Test 4: Wrong password — should return false
        [Fact]
        public void Login_WithWrongPassword_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeUserRepository();
            var service = new AuthService(fakeRepo);
            service.Register("test@mail.com", "1234");

            // Act
            bool result = service.Login("test@mail.com", "wrong");

            // Assert
            Assert.False(result);
        }
    }
}
