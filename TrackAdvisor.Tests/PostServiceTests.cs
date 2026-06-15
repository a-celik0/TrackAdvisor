using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS;
using TrackAdvisor.BLL.Services;
using Xunit;

namespace TrackAdvisor.Tests
{
    public class PostServiceTests
    {
        //Test 1
        [Fact]
        public void AddExperiencePost_WithValidData_ReturnsTrue()
        {
            // Arrange
            var fakeRepo = new FakePostRepository();
            var service = new PostService(fakeRepo);

            // Act
            bool result = service.CreatePost(new ExperiencePost
            {
                Content = "I found it very helpful for choosing a career track.",
                TopicID = 1,
                UserID = 1
            });
            // Assert
            Assert.True(result);
        }

        //Test 2 
        [Fact]

        public void AddExperiencePost_WithInvalidData_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakePostRepository();
            var service = new PostService(fakeRepo);
            // Act
            bool result = service.CreatePost(new ExperiencePost
            {
                Content = "", // Invalid content
                TopicID = 1,
                UserID = 1
            });
            // Assert
            Assert.False(result);

        }

        //Test 3
        [Fact]
        public void GetPostsByTopic_WithValidTopicId_ReturnsPosts()
        {
            // Arrange
            var fakeRepo = new FakePostRepository();
            var service = new PostService(fakeRepo);
            service.CreatePost(new ExperiencePost
            {
                Content = "Great insights on the topic!",
                TopicID = 1,
                UserID = 1
            });
            // Act
            var posts = service.GetPostsByTopic(1);
            // Assert
            Assert.NotEmpty(posts);
        }

        // Test 4: Null post object — should throw ArgumentNullException
        [Fact]
        public void CreatePost_WithNullPost_ThrowsException()
        {
            // Arrange
            var fakeRepo = new FakePostRepository();
            var service = new PostService(fakeRepo);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.CreatePost(null));
        }

        // Test 5: Posts from different topic should not be returned
        [Fact]
        public void GetPostsByTopic_WithDifferentTopicId_ReturnsEmpty()
        {
            // Arrange
            var fakeRepo = new FakePostRepository();
            var service = new PostService(fakeRepo);
            service.CreatePost(new ExperiencePost { Content = "Great track!", TopicID = 1, UserID = 1 });

            // Act
            var posts = service.GetPostsByTopic(2);

            // Assert
            Assert.Empty(posts);
        }
    }
}
