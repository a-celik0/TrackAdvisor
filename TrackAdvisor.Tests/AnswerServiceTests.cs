using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;
using Xunit;

namespace TrackAdvisor.Tests
{
        public class AnswerServiceTests
        {
            // Test 1: Valid answer data — should return true
            [Fact]
            public void SubmitAnswer_WithValidData_ReturnsTrue()
            {
                // Arrange
                var fakeRepo = new FakeAnswerRepository();
                var service = new AnswerService(fakeRepo);

                // Act
                bool result = service.SubmitAnswer(new Answer { Content = "TrackAdvisor is a platform for sharing experiences.", QuestionID = 1, UserID = 1 });

                // Assert
                Assert.True(result);
            }

            // Test 2: Empty answer content — should return false
            [Fact]
            public void SubmitAnswer_WithEmptyContent_ReturnsFalse()
            {
                // Arrange
                var fakeRepo = new FakeAnswerRepository();
                var service = new AnswerService(fakeRepo);

                // Act
                bool result = service.SubmitAnswer(new Answer { Content = "", QuestionID = 1, UserID = 1 });

                // Assert
                Assert.False(result);
            }

            // Test 3: Get answers by question — should return correct list
            [Fact]
            public void GetAnswersByQuestion_WithExistingQuestion_ReturnsAnswers()
            {
                // Arrange
                var fakeRepo = new FakeAnswerRepository();
                var service = new AnswerService(fakeRepo);
                service.SubmitAnswer(new Answer { Content = "TrackAdvisor is a platform for sharing experiences.", QuestionID = 1, UserID = 1 });
                service.SubmitAnswer(new Answer { Content = "You can ask questions and get answers from the community.", QuestionID = 1, UserID = 1 });

                // Act
                var answers = service.GetByQuestion(1);

                // Assert
                Assert.Equal(2, answers.Count);
                Assert.Contains(answers, a => a.Content == "TrackAdvisor is a platform for sharing experiences.");
                Assert.Contains(answers, a => a.Content == "You can ask questions and get answers from the community.");
            }
        }
    }
