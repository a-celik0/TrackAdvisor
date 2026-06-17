using TrackAdvisor.BLL.Services;
using Xunit;

namespace TrackAdvisor.Tests
{
    public class TopicServiceTests
    {
        // Test 1: Valid topic data — should return true
        [Fact]
        public void AddTopic_WithValidData_ReturnsTrue()
        {
            // Arrange
            var fakeRepo = new FakeTopicRepository();
            var service = new TopicService(fakeRepo);

            // Act
            bool result = service.AddTopic("Software Development", "Software development track");

            // Assert
            Assert.True(result);
        }

        // Test 2: Empty name — should return false
        [Fact]
        public void AddTopic_WithEmptyName_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeTopicRepository();
            var service = new TopicService(fakeRepo);

            // Act
            bool result = service.AddTopic("", "Some description");

            // Assert
            Assert.False(result);
        }

        // Test 3: Empty description — should return false
        [Fact]
        public void AddTopic_WithEmptyDescription_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeTopicRepository();
            var service = new TopicService(fakeRepo);

            // Act
            bool result = service.AddTopic("Cyber Security", "");

            // Assert
            Assert.False(result);
        }

        // Test 4: Update topic with valid data — should return true
        [Fact]
        public void UpdateTopic_WithValidData_ReturnsTrue()
        {
            // Arrange
            var fakeRepo = new FakeTopicRepository();
            var service = new TopicService(fakeRepo);
            service.AddTopic("Business IT", "Business IT track");

            // Act
            bool result = service.UpdateTopic(1, "Business IT Updated", "Updated description");

            // Assert
            Assert.True(result);
        }

        // Test 5: Update topic with empty name — should return false
        [Fact]
        public void UpdateTopic_WithEmptyName_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeTopicRepository();
            var service = new TopicService(fakeRepo);
            service.AddTopic("Business IT", "Business IT track");

            // Act
            bool result = service.UpdateTopic(1, "", "Updated description");

            // Assert
            Assert.False(result);
        }

        // Test 6: Get all topics — should not include deleted topics
        [Fact]
        public void GetAllTopics_ReturnsOnlyActiveTopics()
        {
            // Arrange
            var fakeRepo = new FakeTopicRepository();
            var service = new TopicService(fakeRepo);
            service.AddTopic("Software Development", "Track 1");
            service.AddTopic("Cyber Security", "Track 2");

            // Act
            var topics = service.GetAllTopics();

            // Assert
            Assert.Equal(2, topics.Count);
        }
    }
}