using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.BLL.Services;

namespace TrackAdvisor.Tests
{
    public class QuestionServiceTests
    {
        //Test 1 : Valid question data — should return true
        [Fact]
        public void AskQuestion_WithValidData_ReturnsTrue()
        {
            // Arrange
            var fakeRepo = new FakeQuestionRepository();
            var service = new QuestionService(fakeRepo);

            // Act
            bool result = service.AskQuestion("What is TrackAdvisor?", 1, 1);

            // Assert
            Assert.True(result);
        }

        //Test 2 : Empty question content — should return false
        [Fact]
        public void AskQuestion_WithEmptyContent_ReturnsFalse()
        {
            // Arrange
            var fakeRepo = new FakeQuestionRepository();
            var service = new QuestionService(fakeRepo);
            // Act
            bool result = service.AskQuestion("", 1, 1);
            // Assert
            Assert.False(result);

        }

        //Test 3 : Get questions by topic — should return correct list
        [Fact]
        public void GetQuestionsByTopic_WithExistingTopic_ReturnsQuestions()
        {
            // Arrange
            var fakeRepo = new FakeQuestionRepository();
            var service = new QuestionService(fakeRepo);
            service.AskQuestion("What is TrackAdvisor?", 1, 1);
            service.AskQuestion("How to use TrackAdvisor?", 1, 1);
            // Act
            var questions = service.GetQuestionsByTopic(1);
            // Assert
            Assert.Equal(2, questions.Count);
            Assert.Contains(questions, q => q.Content == "What is TrackAdvisor?");
            Assert.Contains(questions, q => q.Content == "How to use TrackAdvisor?");
        }
    }
}
