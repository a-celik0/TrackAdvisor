using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.Tests
{
    public class QuestionServiceTests
    {
        // Test 1: Valid question data — should return true
        [Fact]
        public void AskQuestion_WithValidData_ReturnsTrue()
        {
            // Arrange
            var fakeRepo = new FakeQuestionRepository();
            var service = new QuestionService(fakeRepo);

            var question = new Question
            {
                Content = "What is TrackAdvisor?",
                TopicID = 1,
                UserID = 1
            };

            // Act
            bool result = service.AskQuestion(question);

            // Assert
            Assert.True(result);
        }

        // Test 2: Empty question content — should return false
        [Fact]
        public void AskQuestion_WithEmptyContent_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeQuestionRepository();
            var service = new QuestionService(fakeRepo);

            var question = new Question
            {
                Content = "",
                TopicID = 1,
                UserID = 1
            };

            // Act
            bool result = service.AskQuestion(question);

            // Assert
            Assert.False(result);
        }

        // Test 3: Get questions by topic — should return correct list
        [Fact]
        public void GetQuestionsByTopic_WithExistingTopic_ReturnsQuestions()
        {
            // Arrange
            var fakeRepo = new FakeQuestionRepository();
            var service = new QuestionService(fakeRepo);

            service.AskQuestion(new Question { Content = "What is TrackAdvisor?", TopicID = 1, UserID = 1 });
            service.AskQuestion(new Question { Content = "How to use TrackAdvisor?", TopicID = 1, UserID = 1 });

            // Act
            var questions = service.GetQuestionsByTopic(1);

            // Assert
            Assert.Equal(2, questions.Count);
            Assert.Contains(questions, q => q.Content == "What is TrackAdvisor?");
            Assert.Contains(questions, q => q.Content == "How to use TrackAdvisor?");
        }
    }
}
